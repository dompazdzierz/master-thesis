using Machine.Specifications;
using System;
using TwojeWesele.Services.Helpers;

namespace MSpecsTestProject
{
    [Subject(typeof(CurrencyHelper))]
    public class FormatToDoubleTest
    {
        static CurrencyHelper Subject;
        static string _price = "2.00 z³";
        static double _priceDouble;
        static double _expected = 2.00;

        Establish context = () => 
            Subject = new CurrencyHelper();

        Because of = () => 
            _priceDouble = Subject.FormatToDouble(_price);

        It should_be_equal_to_expected_double_price = () =>
            _expected.ShouldEqual(_priceDouble);
    }
}
