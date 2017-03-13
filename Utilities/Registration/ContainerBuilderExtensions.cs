using System;
using Autofac;
using Autofac.Core;

namespace Utilities.Registration
{
    public static class ContainerBuilderExtensions
    {
        /// <summary>
        ///     Register a resource as Instance Per Reguest (IPR).
        ///     Try to make registering as terse as possible as this is highly repetitive.
        /// </summary>
        /// <remarks>
        ///     C# generics don't allow one type to be provided and one infered, so only
        ///     use generic parameters for the types that are inferred.
        /// </remarks>
        public static ContainerBuilder RegisterAsIpr<T>(
            this ContainerBuilder builder,
            System.Type interfaceType,
            Func<IComponentContext, T> factory)
        {
            builder
                .Register(factory)
                .As(new TypedService(interfaceType))
                .InstancePerRequest();
            return builder;
        }

        public static ContainerBuilder RegisterIpr<T>(
            this ContainerBuilder builder,
            Func<IComponentContext, T> factory)
        {
            builder
                .Register(factory)
                .InstancePerRequest();
            return builder;
        }
    }
}
