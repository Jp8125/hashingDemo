using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
class HashingDemo {
static void Main(String[] args)
    {
        var hash=new HashingDemo();
        var res = hash.CreateHash("demo");
        Console.WriteLine("hash: "+res.Item1);
        Console.WriteLine("salt: "+res.Item2);

        var result=hash.VerifyHash("demo",res.Item1,res.Item2);
        Console.WriteLine(result);
    }

    //public Tuple<string, string> CreateHash(string password)
    //{

    //        var hmac = new HMACSHA256();
    //        var salt = Convert.ToBase64String(hmac.Key);
    //        var hmacToComputehash = new HMACSHA256(Encoding.UTF8.GetBytes(salt));
    //        var hash = hmacToComputehash.ComputeHash(Encoding.UTF8.GetBytes(password));
    //        return Tuple.Create(Convert.ToBase64String(hash), salt);

    //}
    //public  bool VerifyHash(string password, string storedHash, string storedSalt)
    //{
    //    using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(storedSalt)))
    //    {
    //        var computedHash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));
    //        return storedHash == computedHash;
    //    }
    //}
    public (string Hash, string Salt) CreateHash(string password)
    {
        using (var hmac = new HMACSHA256())
        {
            var hamcForhash = new HMACSHA256(hmac.Key);
            var salt = Convert.ToBase64String(hmac.Key);
            var hash = Convert.ToBase64String(hamcForhash.ComputeHash(Encoding.UTF8.GetBytes(password)));
            return (hash, salt);
        }
    }

    public bool VerifyHash(string password, string storedHash, string storedSalt)
    {
        using (var hmac = new HMACSHA256(Convert.FromBase64String(storedSalt)))
        {
            var computedHash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));
            Console.WriteLine("hash: " + computedHash);

            return storedHash == computedHash;
        }
    }

}