
using Xunit;
using LoanApp;
namespace LoanApp.Tests
{
public class LoanEvaluatorTests
{
 [Fact]
 public static void IsBelowMinIncome_ShouldReturnTrueWhenIncomeLessThan2000()
{
 var result = Invoke("IsBelowMinimumIncome", 1600);
 Assert.True((bool)result);
}

[Fact]
public static void IsBelowMinIncome_ShouldReturnFalseWhenIncomeIs2000OrMore()
{
var result = Invoke("IsBelowMinimumIncome", 2600);
Assert.False((bool)result);
}

[Fact]
public static void EvaluateHighCredit_ShouldReturnEligibleWhenDependentsIsZero()
{
 var result = Invoke("EvaluateHighCreditPath", 0);
 Assert.Equal("Eligible", result);
}

 [Fact]
 public static void  EvaluateHighCredit_Should_ReturnReview_When_DependentsIsTwo()
 {
 var result = Invoke("EvaluateHighCreditPath", 2);
 Assert.Equal("Review Manually", result);
 }

 [Fact]
 public static void EvaluateHighCredit_Should_ReturnNotEligible_When_DependentsGreaterThanTwo()
 {
 var result = Invoke("EvaluateHighCreditPath",4);
 Assert.Equal("Not Eligible", result);
 }

 [Fact]
 public static void EvaluateMedCredit_Should_ReturnReview_When_OwnsHouse()
 {
 var result = Invoke("EvaluateMediumCreditPath", true);
 Assert.Equal("Review Manually", result);
}

[Fact]
 public static void  EvaluateMedCredit_Should_ReturnNotEligible_When_NotOwnsHouse()
{
 var result = Invoke("EvaluateMediumCreditPath", false);
 Assert.Equal("Not Eligible", result);
 }
 [Fact]
        public static void EvaluateNoJobPath_Should_ReturnEligible_When_HighCreditAndIncomeAndOwnsHouse()
        {
            var result = Invoke("EvaluateNoJobPath", 6000, 760, 1, true);
            Assert.Equal("Eligible", result);
        }

        [Fact]
        public static void EvaluateNoJobPath_Should_ReturnReview_When_CreditAbove650AndNoDependents()
        {
            var result = Invoke("EvaluateNoJobPath", 3500, 660, 0, false);
            Assert.Equal("Review Manually", result);
        }

        [Fact]
        public static void EvaluateNoJobPath_Should_ReturnNotEligible_When_ConditionsNotMet()
        {
            var result = Invoke("EvaluateNoJobPath", 3000, 600, 1, false);
            Assert.Equal("Not Eligible", result);
        }

        [Fact]
        public static void EvaluateHasJob_Should_ReturnHighCreditPath_When_CreditAbove700()
        {
            var result = Invoke("EvaluateHasJob", 750, 1, true);
            Assert.Equal("Review Manually", result);
        }

        [Fact]
        public static void EvaluateHasJob_Should_ReturnMediumCreditPath_When_CreditAbove600AndOwnsHouse()
        {
            var result = Invoke("EvaluateHasJob", 650, 2, true);
            Assert.Equal("Review Manually", result);
        }

        [Fact]
        public static void EvaluateHasJob_Should_ReturnNotEligible_When_LowCreditScore()
        {
            var result = Invoke("EvaluateHasJob", 550, 1, false);
            Assert.Equal("Not Eligible", result);
        }

}
}