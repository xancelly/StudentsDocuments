using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsDocuments.Entities
{
    public partial class Organization
    {
        public string Details
        {
            get
            {
                if (BankDetail.PersonalAccount == null || BankDetail.PersonalAccount == "")
                {
                    return "р/с " + BankDetail.PaymentAccount + " в " + BankDetail.BankName + " к/с " + BankDetail.CorrespondentAccount + " БИК " + BankDetail.BIK; 
                } else
                {
                    return $"Министерство экономики и финансов Московской области (л/с {BankDetail.PersonalAccount} {Name}) р/с {BankDetail.PaymentAccount} в {BankDetail.BankName} БИК {BankDetail.BIK}";  
                }
            }
        }
    }
}
