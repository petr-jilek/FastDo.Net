namespace FastDo.Net.Domain.Errors.Models
{
    public class ErrorCode
    {
        public int Block { get; }
        public int Code { get; set; }

        public ErrorCode(int block, int code)
        {
            Block = block;
            Code = code;
        }

        public ErrorCode(string value)
        {
            var splitted = value.Split('.');
            Block = int.Parse(splitted[0]);
            Code = int.Parse(splitted[1]);
        }

        public static implicit operator string(ErrorCode errorCode) => $"{errorCode.Block}.{errorCode.Code}";
        public static explicit operator ErrorCode(string str) => new(str);

        public override bool Equals(object? obj)
        {
            if (obj is null)
                return false;

            // Optimization for a common success case.
            if (ReferenceEquals(this, obj))
                return true;

            // If run-time types are not exactly the same, return false.
            if (GetType() != obj.GetType())
                return false;

            var errorCode = (ErrorCode)obj;

            // Return true if the fields match.
            // Note that the base class is not invoked because it is
            // System.Object, which defines Equals as reference equality.
            return (Block == errorCode.Block) && (Code == errorCode.Code);
        }

        public static bool operator ==(ErrorCode lhs, ErrorCode rhs)
        {
            if (lhs is null)
            {
                if (rhs is null)
                    return true;

                // Only the left side is null.
                return false;
            }
            // Equals handles case of null on right side.
            return lhs.Equals(rhs);
        }

        public static bool operator !=(ErrorCode lhs, ErrorCode rhs) => !(lhs == rhs);

        public override string ToString()
        {
            return $"{Block}.{Code}";
        }

        public override int GetHashCode()
        {
            return Block * 10 ^ 5 + Code;
        }
    }
}
