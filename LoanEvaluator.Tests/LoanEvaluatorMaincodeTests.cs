using Xunit;
using LoanApp;
namespace LoanApp.Tests
{
   public static class LoanEvaluatorMaincodeTests
{
    [Fact]
    public void GetLoanEligibility_Should_ReturnNotEligible_When_IncomeIsLow()
    {
        var result = GetLoanEligibility(1200, true, 620, 1, false);
        Assert.Equal("Not Eligible", result);
    }

    [Fact]
    public void GetLoanEligibility_Should_ReturnEligible_When_HasJobWithHighCredit()
    {
        var result = GetLoanEligibility(7000, true, 800, 0, true);
        Assert.Equal("Eligible", result);
    }

    [Fact]
    public void GetLoanEligibility_Should_ReturnReviewManually_When_HasJobWithMediumCreditAndOwnsHouse()
    {
        var result = GetLoanEligibility(4500, true, 630, 1, true);
        Assert.Equal("Review Manually", result);
    }

    [Fact]
    public void GetLoanEligibility_Should_ReturnNotEligible_When_HasJobWithLowCredit()
    {
        var result = GetLoanEligibility(2800, true, 500, 2, false);
        Assert.Equal("Not Eligible", result);
    }

    [Fact]
    public void GetLoanEligibility_Should_ReturnEligible_When_NoJobWithHighCreditAndOwnsHouse()
    {
        var result = GetLoanEligibility(7200, false, 780, 1, true);
        Assert.Equal("Eligible", result);
    }

    [Fact]
    public void GetLoanEligibility_Should_ReturnReviewManually_When_NoJobWithMediumCreditAndNoDependents()
    {
        var result = GetLoanEligibility(3600, false, 640, 0, false);
        Assert.Equal("Review Manually", result);
    }

    [Fact]
    public void GetLoanEligibility_Should_ReturnNotEligible_When_NoJobWithLowCredit()
    {
        var result = GetLoanEligibility(2200, false, 570, 1, false);
        Assert.Equal("Not Eligible", result);
    }
}

}