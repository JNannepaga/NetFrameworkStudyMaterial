using System;

namespace EntityFramework.FluentAPI.OnetoOneMapping
{
    public class RegularCustomer : Customer
    {
        #region Properties
        //Scalar Properties
        public decimal AdvCredits { get; set; }
        public string Perks { get; set; }

        //Navigational Properties
        public virtual Catelog Catelog { get; set; }
        #endregion
    }
}
