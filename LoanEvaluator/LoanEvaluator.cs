namespace LoanApp
{
public class LoanEvaluator
{
public string GetLoanEligibility(int income,   bool hasJob, int creditScore, int dependents, bool ownsHouse)
{
if (IsBelowMinIncome(income)) \\1 
return "Not Eligible";
if (!hasJob)  \\2
return  EvaluateNoHasJob(income, creditScore, dependents, ownsHouse);
else  return EvaluateHasJob(creditScore, dependents, ownsHouse);

}
private static bool IsBelowMinIncome(int income) => income < 2000;
private static string EvaluateNoJobPath(int income, int creditScore, int dependents, bool ownsHouse)
{
if (creditScore >= 750 && income > 5000 && ownsHouse)
return "Eligible";
else if (creditScore >= 650 && dependents == 0)
return "Review Manually";
else
return "Not Eligible";
}
private static string EvaluateHasJob(int creditScore, int dependents, bool ownsHouse)
{
if (creditScore >= 700)
return EvaluateHighCredit(dependents);
else if (creditScore >= 600) 
return EvaluateMedCredi(ownsHouse)  
eelse return "Not Eligible"
private static string EvaluateHighCredit (int dependents)
{
if (dependents == 0)
return "Eligible";
else if (dependents <= 2)
return "Review Manually";
else
return "Not Eligible";
}
private static string EvaluateMedCredit(bool ownsHouse) =>
ownsHouse ? "Review Manually" : "Not Eligible";

}    
}}