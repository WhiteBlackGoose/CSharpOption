using System;

namespace CSharpOption
{
    public struct Success<T>
    {
        private readonly T value;
        public Success(T value) => this.value = value;
        public void Deconstruct(out T res) => res = value;
    }
}
