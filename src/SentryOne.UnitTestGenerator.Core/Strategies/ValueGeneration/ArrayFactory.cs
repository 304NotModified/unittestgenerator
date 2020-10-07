﻿namespace SentryOne.UnitTestGenerator.Core.Strategies.ValueGeneration
{
    using System;
    using System.Collections.Generic;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using SentryOne.UnitTestGenerator.Core.Frameworks;
    using SentryOne.UnitTestGenerator.Core.Helpers;

    public static class ArrayFactory
    {
        public static ExpressionSyntax ImplicitlyTypedArray(ITypeSymbol typeSymbol, SemanticModel model, HashSet<string> visitedTypes, IFrameworkSet frameworkSet)
        {
            if (typeSymbol is IArrayTypeSymbol arrayTypeSymbol)
            {
                if (visitedTypes.Contains(arrayTypeSymbol.ElementType.ToFullName()))
                {
                    return SyntaxFactory.ArrayCreationExpression(SyntaxFactory.ArrayType(arrayTypeSymbol.ElementType.ToTypeSyntax(frameworkSet.Context)));
                }

                return SyntaxFactory.ImplicitArrayCreationExpression(
                    SyntaxFactory.InitializerExpression(
                        SyntaxKind.ArrayInitializerExpression,
                        SyntaxFactory.SeparatedList<ExpressionSyntax>(
                            new SyntaxNodeOrToken[]
                            {
                                AssignmentValueHelper.GetDefaultAssignmentValue(arrayTypeSymbol.ElementType, model, new HashSet<string>(visitedTypes, StringComparer.OrdinalIgnoreCase), frameworkSet),
                                SyntaxFactory.Token(SyntaxKind.CommaToken),
                                AssignmentValueHelper.GetDefaultAssignmentValue(arrayTypeSymbol.ElementType, model, new HashSet<string>(visitedTypes, StringComparer.OrdinalIgnoreCase), frameworkSet),
                                SyntaxFactory.Token(SyntaxKind.CommaToken),
                                AssignmentValueHelper.GetDefaultAssignmentValue(arrayTypeSymbol.ElementType, model, new HashSet<string>(visitedTypes, StringComparer.OrdinalIgnoreCase), frameworkSet),
                            })));
            }

            var random = ValueGenerationStrategyFactory.Random;
            return SyntaxFactory.InvocationExpression(
                    SyntaxFactory.MemberAccessExpression(
                        SyntaxKind.SimpleMemberAccessExpression,
                        SyntaxFactory.IdentifierName("Array"),
                        SyntaxFactory.IdentifierName("CreateInstance")))
                .WithArgumentList(
                    Generate.Arguments(SyntaxFactory.TypeOfExpression(SyntaxFactory.IdentifierName("int")), Generate.Literal(random.Next(int.MaxValue)), Generate.Literal(random.Next(int.MaxValue)), Generate.Literal(random.Next(int.MaxValue))));
        }

        public static ExpressionSyntax ImplicitlyTyped(ITypeSymbol typeSymbol, SemanticModel model, HashSet<string> visitedTypes, IFrameworkSet frameworkSet)
        {
            if (typeSymbol is INamedTypeSymbol namedTypeSymbol && namedTypeSymbol.TypeArguments.Length > 0)
            {
                var targetType = namedTypeSymbol.TypeArguments[0];

                if (visitedTypes.Contains(targetType.ToFullName()))
                {
                    return SyntaxFactory.ArrayCreationExpression(SyntaxFactory.ArrayType(targetType.ToTypeSyntax(frameworkSet.Context)));
                }

                return SyntaxFactory.ImplicitArrayCreationExpression(
                    SyntaxFactory.InitializerExpression(
                        SyntaxKind.ArrayInitializerExpression,
                        SyntaxFactory.SeparatedList<ExpressionSyntax>(
                            new SyntaxNodeOrToken[]
                            {
                                AssignmentValueHelper.GetDefaultAssignmentValue(targetType, model, new HashSet<string>(visitedTypes, StringComparer.OrdinalIgnoreCase), frameworkSet),
                                SyntaxFactory.Token(SyntaxKind.CommaToken),
                                AssignmentValueHelper.GetDefaultAssignmentValue(targetType, model, new HashSet<string>(visitedTypes, StringComparer.OrdinalIgnoreCase), frameworkSet),
                                SyntaxFactory.Token(SyntaxKind.CommaToken),
                                AssignmentValueHelper.GetDefaultAssignmentValue(targetType, model, new HashSet<string>(visitedTypes, StringComparer.OrdinalIgnoreCase), frameworkSet),
                            })));
            }

            return AssignmentValueHelper.GetDefaultAssignmentValue(typeSymbol, model, frameworkSet);
        }

        public static ExpressionSyntax Byte()
        {
            return SyntaxFactory.ArrayCreationExpression(
                    SyntaxFactory.ArrayType(
                            SyntaxFactory.PredefinedType(
                                SyntaxFactory.Token(SyntaxKind.ByteKeyword)))
                        .WithRankSpecifiers(
                            SyntaxFactory.SingletonList(
                                SyntaxFactory.ArrayRankSpecifier(
                                    SyntaxFactory.SingletonSeparatedList<ExpressionSyntax>(
                                        SyntaxFactory.OmittedArraySizeExpression())))))
                .WithInitializer(
                    SyntaxFactory.InitializerExpression(
                        SyntaxKind.ArrayInitializerExpression,
                        SyntaxFactory.SeparatedList<ExpressionSyntax>(
                            new SyntaxNodeOrToken[]
                            {
                                Generate.Literal((byte)ValueGenerationStrategyFactory.Random.Next(255)),
                                SyntaxFactory.Token(SyntaxKind.CommaToken),
                                Generate.Literal((byte)ValueGenerationStrategyFactory.Random.Next(255)),
                                SyntaxFactory.Token(SyntaxKind.CommaToken),
                                Generate.Literal((byte)ValueGenerationStrategyFactory.Random.Next(255)),
                                SyntaxFactory.Token(SyntaxKind.CommaToken),
                                Generate.Literal((byte)ValueGenerationStrategyFactory.Random.Next(255)),
                            })));
        }
    }
}