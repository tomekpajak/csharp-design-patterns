using System;

namespace tp.Proxy
{
    interface IDoor
    {
        String Open();
        String Close();
    }

    class BasicDoor : IDoor
    {
        public string Open() => "Opening door";
        public string Close() => "Closing door";
    }

    class SecuredDoor : IDoor
    {
        private IDoor _door;
        private String _password;
        
        public SecuredDoor(String password) => this._password = password;
        public string Close()
        {
            if (_door == null)
                _door = new BasicDoor();

            return _door.Close();
        }

        public string Open()
        {
            if (!Authenticate)
                return "Invalid password";

            if (_door == null)
                _door = new BasicDoor();

            return _door.Open();
        }
        private bool Authenticate => this._password == "p@ssw0rd";
    }

    class Program
    {
        static void Main(string[] args)
        {
            var basicDoor = new BasicDoor();
            var invalidPassSecuredDoor = new SecuredDoor("password");
            var securedDoor = new SecuredDoor("p@ssw0rd");

            Console.WriteLine($"Open basic door: {basicDoor.Open()}");
            Console.WriteLine($"Open secure door (password): {invalidPassSecuredDoor.Open()}");
            Console.WriteLine($"Open secure door (p@ssw0rd): {securedDoor.Open()}");
        }
    }
}
