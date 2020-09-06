﻿namespace SentryOne.UnitTestGenerator.Core.Strategies.OperatorGeneration
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using SentryOne.UnitTestGenerator.Core.Frameworks;
    using SentryOne.UnitTestGenerator.Core.Helpers;
    using SentryOne.UnitTestGenerator.Core.Models;
    using SentryOne.UnitTestGenerator.Core.Resources;

    public class CanCallOperatorGenerationStrategy : IGenerationStrategy<IOperatorModel>
    {
        private readonly IFrameworkSet _frameworkSet;

        public CanCallOperatorGenerationStrategy(IFrameworkSet frameworkSet)
        {
            _frameworkSet = frameworkSet ?? throw new ArgumentNullException(nameof(frameworkSet));
        }

        public bool IsExclusive => false;

        public int Priority => 1;

        public bool CanHandle(IOperatorModel method, ClassModel model)
        {
            if (method is null)
            {
                throw new ArgumentNullException(nameof(method));
            }

            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return true;
        }

        public IEnumerable<MethodDeclarationSyntax> Create(IOperatorModel method, ClassModel model)
        {
            if (method is null)
            {
                throw new ArgumentNullException(nameof(method));
            }

            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var methodName = string.Format(CultureInfo.InvariantCulture, _frameworkSet.TestNamingConventions.CanCallMethodNaming, $"{method.Name}Operator");

            var generatedMethod = _frameworkSet.TestFramework.CreateTestMethod(methodName, false, model.IsStatic);

            var paramExpressions = new List<CSharpSyntaxNode>();

            foreach (var parameter in method.Parameters)
            {
                var defaultAssignmentValue = AssignmentValueHelper.GetDefaultAssignmentValue(parameter.TypeInfo, model.SemanticModel, _frameworkSet);

                generatedMethod = generatedMethod.AddBodyStatements(SyntaxFactory.LocalDeclarationStatement(
                    SyntaxFactory.VariableDeclaration(SyntaxFactory.IdentifierName(Strings.Create_var))
                                 .WithVariables(SyntaxFactory.SingletonSeparatedList(
                                                   SyntaxFactory.VariableDeclarator(SyntaxFactory.Identifier(parameter.Name))
                                                                .WithInitializer(SyntaxFactory.EqualsValueClause(defaultAssignmentValue))))));

                paramExpressions.Add(SyntaxFactory.IdentifierName(parameter.Name));
            }

            var methodCall = method.Invoke(model, false, _frameworkSet, paramExpressions.ToArray());

            var bodyStatement = SyntaxFactory.LocalDeclarationStatement(
                SyntaxFactory.VariableDeclaration(
                        SyntaxFactory.IdentifierName(Strings.Create_var))
                    .WithVariables(
                        SyntaxFactory.SingletonSeparatedList(
                            SyntaxFactory.VariableDeclarator(
                                    SyntaxFactory.Identifier(Strings.CanCallMethodGenerationStrategy_Create_result))
                                .WithInitializer(
                                    SyntaxFactory.EqualsValueClause(methodCall)))));

            generatedMethod = generatedMethod.AddBodyStatements(bodyStatement);

            generatedMethod = generatedMethod.AddBodyStatements(_frameworkSet.TestFramework.AssertFail(Strings.PlaceholderAssertionMessage));

            yield return generatedMethod;
        }
    }
}