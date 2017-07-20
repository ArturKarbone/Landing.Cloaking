using CoreFire;
using System;

namespace Landing.Cloaking.Firebase
{
    class FirebaseRepository
    {
        public string Url => Environment.GetEnvironmentVariable("firebase-url");

        public Client Client
        {
            get
            {
                return Client.Builder()
                    .WithUri(new Uri(Url))
                    .Build();
            }
        }
    }
}
