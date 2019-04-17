namespace Common.Persistence.Models
{
    public class Token
    {
        private readonly string _key;
        private readonly string _value;
        private readonly bool _neverHtmlEncoded;

        /// <summary>
        /// Token key
        /// </summary>
        public string GetKey()
        { return _key; }
        /// <summary>
        /// Token value
        /// </summary>
        public string GetValue()
        { return _value; }
        /// <summary>
        /// Indicates whether this token should not be HTML encoded
        /// </summary>
        public bool GetNeverHtmlEncoded()
        { return _neverHtmlEncoded; }

        public Token(string key, string value, bool neverHtmlEncoded = false)
        {
            _key = key;
            _value = value;
            _neverHtmlEncoded = neverHtmlEncoded;
        }

        public override string ToString()
        {
            return string.Format("{0}: {1}", _key, _value);
        }
    }
}
