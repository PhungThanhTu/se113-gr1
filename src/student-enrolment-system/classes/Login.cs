using System;


namespace student_enrolment_system
{ 
    public class Account {
        public string Username;
        public string Password;
        public string AccountType;
        // error
        // admin
        // teacher

        public Account(string usr,string pss)
        {
            Username = usr;
            Password = pss;
        }

        public override bool Equals(object obj)
        {   
            //Check for null and compare run-time types.
            if ((obj == null) || ! this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            Account a = (Account) obj;
            return this.AccountType == a.AccountType && this.Username == a.Username && this.Password == a.Password;
           
        }
    }
    public class Login {
        // query related data
        const string ACCOUNT_TABLE_NAME = "";
        const string ACCOUNT_TABLE_FIELD_USERNAME = "";
        const string ACCOUNT_TABLE_FIELD_PASSWORD = "";
        const string ACCOUNT_TABLE_FIELD_ACCOUNT_TYPE = "";


        // read input
        public static Account inputAccount(string username,string password){
            if(string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)) return null;
            return new Account(username,password);
        }
        // query username to database to get username and password based on input username
        public static Account getQueriedAccount(Account inputAccount)
        {   
            // get password from database based on username
            string Password = ExecuteQuery.GetStringFromQuery("Select "+ ACCOUNT_TABLE_FIELD_PASSWORD +" from "+ ACCOUNT_TABLE_NAME + " where "
            + ACCOUNT_TABLE_FIELD_USERNAME + " = " + inputAccount.Username
            );

            // if password = null, return null 
            if( Password == null)
                return null;
            // if password is not null, return the queried account with account type
            else 
            {   
                // get account type from database
                string AccountType = ExecuteQuery.GetStringFromQuery("Select "+ ACCOUNT_TABLE_FIELD_ACCOUNT_TYPE +" from "+ ACCOUNT_TABLE_NAME + " where "
                + ACCOUNT_TABLE_FIELD_USERNAME + " = " + inputAccount.Username
                );

                Account QueriedAccount = new Account(inputAccount.Username, Password);
                QueriedAccount.AccountType = AccountType;

                return QueriedAccount;
            }
        }

        // check if password is true
        public static bool checkAuthentication(Account inputAccount, Account queriedAccount)
        {
            // if queried account is null, authentication failed
            if(queriedAccount == null) return false;

            // if error in check account type, authentication failed too
            if(queriedAccount.AccountType == "error") return false;
            // then, check if password is correct
            return queriedAccount.Password == inputAccount.Password;
        }
        
        // give account type to the input account 
        public static Account getVerifiedAccount(Account inputAccount, Account queriedAccount)
        {
            if(!checkAuthentication(inputAccount,queriedAccount)) inputAccount.AccountType = "error"; // error authentication make real account type error
            else inputAccount.AccountType = queriedAccount.AccountType;

            return inputAccount; 
        }
        public static string LoginResult(Account verifiedAccount)
        {
            return verifiedAccount.AccountType;
        }

        
    }
}