using App.ApplicationCore.Domain;
using App.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationCore.Services
{
    public class BeneficiaryService : Service<Beneficiary>,IBeneficiaryService
    {
        public BeneficiaryService(IUnitOfWork unitOfWork) : base(unitOfWork)
        { }

        public IEnumerable<Beneficiary> GetBeneficiariesWithKafala()
        {
            return GetMany( b => b.kafalas.Where(k => k.StartDate.Date <= DateTime.Now.Date ).Count() > 0);
        }
    }
}
