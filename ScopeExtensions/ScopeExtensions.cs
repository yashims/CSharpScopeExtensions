using System;

namespace ScopeExtensions
{
    public static class ScopeExtensions
    {
        /// <summary>
        /// 'Also' is myself pass to arguments lambda and return myself.
        /// </summary>
        public static T Also<T>(this T self, Action<T> action)
        {
            action(self);
            return self;
        }

        /// <summary>
        /// NOTE: Kotlin's Apply change this context to myself when run in lambda.
        /// TODO: How to execute Action<T> in T's this context?
        /// </summary>
        public static T Apply<T>(this T self, Action<T> action)
        {
            return self.Also(action);
        }

        /// <summary>
        /// 'Let' is myself pass to arguments lambda and returns returned value from lambda.
        /// </summary>
        public static R Let<T, R>(this T self, Func<T, R> action)
        {
            return action(self);
        }

        public static R Run<R>(Func<R> action)
        {
            return action();
        }

        /// <summary>
        /// NOTE: Kotlin's Run change this context to myself when run in lambda.
        /// TODO: How to execute Func<T> in T's this context?
        /// </summary>
        public static R Run<T, R>(this T self, Func<T, R> action)
        {
            return self.Let(action);
        }
    }
}