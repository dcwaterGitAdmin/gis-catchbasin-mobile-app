using System;

namespace DCWaterMobile.MaximoService
{
    public class MaximoCreds
    {
        readonly string _userName;
        readonly string _password;
        public string JSessionToken { get; set; }
        public string LoginID
        {
            get
            {
                return _userName;
            }
        }

        public MaximoCreds(string userName, string password)
        {
            _userName = userName;
            _password = password;
        }

        public string getMaxAuthHeader()
        {
            string strAuth = _userName + ":" + _password;
            strAuth = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(strAuth));
            return strAuth;
        }

    }
}
