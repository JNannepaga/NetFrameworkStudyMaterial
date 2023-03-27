using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace EntityFramework.FluentAPI.OnetoOneMapping
{
    public class OnetoOneImplementor
    {
        public static void Encounter()
        {
            
            Customer c1 = new RegularCustomer()
            {
                FirstName = "Shreya",
                LastName = "Nans",
                Gender = Gender.Female,
                AdvCredits = 150,
                Perks = "Swiggle",
                Catelog = new Catelog("SplZone", "ABC123", true),
                CustomerRequisites = new CustomerRequisite("9676518138", IdProofType.PANCard, "AQXPN5630N")
            };

            Customer c2 = new GeneralCustomer()
            {
                FirstName = "Shreya",
                LastName = "Nans",
                Gender = Gender.Female,
                Credits = 10,
                NormalCoupon = "Order 40",
                CustomerRequisites = new CustomerRequisite("9676518138", IdProofType.AadharCard, "2567810986")
            };

            
            ValidationContext validationContext_c1 = new ValidationContext(c1);
            ValidationContext validationContext_c2 = new ValidationContext(c2);

            List<ValidationResult> validationResults = new List<ValidationResult>();
            if (Validator.TryValidateObject(c1, validationContext_c1, validationResults, true)
                && Validator.TryValidateObject(c2, validationContext_c2, validationResults, true))
            {
                using (ApplicationDbContext dbContext = new ApplicationDbContext())
                {
                    dbContext.Customers.Add(c1);
                    dbContext.Customers.Add(c2);
                    dbContext.SaveChanges();
                    
                    List<RegularCustomer> regularCustomers = dbContext.Customers
                                                        .Include("CustomerRequisites")
                                                        .OfType<RegularCustomer>()
                                                        .ToList();

                    List<GeneralCustomer> generalCustomers = dbContext.Customers
                                                        .Include("CustomerRequisites")
                                                        .OfType<GeneralCustomer>()
                                                        .ToList();

                    regularCustomers.ForEach(customer =>
                    {
                        Console.WriteLine(
                       $"Customer Details:: {customer.CustomerId} \nName : {customer.FullName} \nGender : {customer.Gender} " +
                       $"\nMobile : {customer.CustomerRequisites?.Mobile} \n{customer.CustomerRequisites?.IdProofType} : {customer.CustomerRequisites?.IdProof}" +
                       $"\nCredits : {customer.AdvCredits} \nPerks : {customer.Perks}" +
                       $"\n{customer.Catelog?.CatelogName} : {customer.Catelog?.CatelogPassword} \nisActivated : {customer.Catelog?.isActive}\n\n");
                    });

                    generalCustomers.ForEach(customer =>
                    {
                        Console.WriteLine(
                        $"Customer Details:: {customer.CustomerId} \nName : {customer.FullName} \nGender : {customer.Gender} " +
                        $"\nMobile : {customer.CustomerRequisites?.Mobile} \n{customer.CustomerRequisites?.IdProofType} : {customer.CustomerRequisites?.IdProof}" +
                        $"\nCredits : {customer.Credits} \nPerks : {customer.NormalCoupon}\n\n");
                    });
                }
            }
            else
            {
                foreach (ValidationResult result in validationResults)
                {
                    Console.WriteLine($"error Msg: {result.ToString()}");
                }
            }
        }
    }
}
