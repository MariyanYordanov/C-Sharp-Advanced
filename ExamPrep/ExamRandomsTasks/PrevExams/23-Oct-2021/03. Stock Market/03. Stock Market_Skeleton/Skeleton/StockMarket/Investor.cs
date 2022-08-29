using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        private readonly List<Stock> portfolio = new List<Stock>();

        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
        }

        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }

        public int Count => portfolio.Count;

        public IReadOnlyCollection<Stock> Portfolio
        {
            get => portfolio;
            set
            {
                Portfolio = portfolio;
            } 
        }

        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10000 && MoneyToInvest > stock.PricePerShare)
            {
                portfolio.Add(stock);
                MoneyToInvest -= stock.PricePerShare;
            }
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            Stock stock = portfolio.FirstOrDefault(x => x.CompanyName == companyName);
            if (stock == null)
            {
                return $"{companyName} does not exist.";
            }
            else if (sellPrice < stock.PricePerShare)
            {
                return $"Cannot sell {companyName}.";
            }
            else
            {
                MoneyToInvest += sellPrice;
                portfolio.Remove(stock);
                return $"{companyName} was sold.";
            }
            
        }

        public Stock FindStock(string companyName) => portfolio.FirstOrDefault(x => x.CompanyName == companyName);

        public Stock FindBiggestCompany() => portfolio.OrderByDescending(x => x.MarketCapitalization).FirstOrDefault();

        public string InvestorInformation()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"The investor {FullName} with a broker {BrokerName} has stocks:");
            foreach (Stock stock in portfolio)
            {
                stringBuilder.AppendLine(stock.ToString());
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
