using System;

namespace ScopeExtensions
{
    public static class ScopeExtensions
    {
        public static T Also<T>(this T self, Action<T> action)
        {
            action(self);
            return self;
        }

        // Kotlin's Apply change this context to myself when run in lambda.
        // TODO: How to execute Action<T> in T's this context?
        public static T Apply<T>(this T self, Action<T> action)
        {
            return self.Also(action);
        }

        public static R Let<T, R>(this T self, Func<T, R> action)
        {
            return action(self);
        }

        public static R Run<R>(Func<R> action)
        {
            return action();
        }

        // Kotlin's Run change this context to myself when run in lambda.
        // TODO: How to execute Func<T> in T's this context?
        public static R Run<T, R>(this T self, Func<T, R> action)
        {
            return self.Let(action);
        }
    }
}