using System.Text.Json.Serialization;

namespace JustOptional
{
    [JsonConverter(typeof(OptionalJsonConverterFactory))]
    public struct Optional<T>
    {
        private T _value;
        
        public bool IsDefined { get; set; }

        public T Value
        {
            get
            {
                return this.IsDefined ? _value : default(T);
            }
            set
            {
                this.IsDefined = true;
                _value = value;
            }
        }

        public static implicit operator T(Optional<T> optional) => optional.Value;

        public static implicit operator Optional<T>(T value) => new Optional<T> { Value = value };
    }
}
