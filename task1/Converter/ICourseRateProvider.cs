namespace Converter;

public interface ICourseRateProvider
{
    decimal GetUsdCourse(Currency currency);
}