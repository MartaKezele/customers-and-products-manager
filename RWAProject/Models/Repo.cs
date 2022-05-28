using Microsoft.ApplicationBlocks.Data;
using RWAProject.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;

namespace RWAProject.Models
{
    public class Repo
    {
        private static readonly string cs = ConfigurationManager.ConnectionStrings["AdventureWorksOBPConnectionString"].ConnectionString;

        // Country

        internal static Country RetrieveCountryByID(int IDCountry)
        {
            DataRow row = SqlHelper.ExecuteDataset(cs, "RetrieveCountryByID", IDCountry).Tables[0].Rows[0];
            return GetCountryFromDataRow(row);
        }

        internal static IEnumerable<Country> RetrieveAllCountries()
        {
            foreach (DataRow row in SqlHelper.ExecuteDataset(cs, "RetrieveAllCountries").Tables[0].Rows)
            {
                yield return GetCountryFromDataRow(row);
            }
        }

        internal static Country RetrieveCountryByCityID(int IDCity)
        {
            DataRow row = SqlHelper.ExecuteDataset(cs, "RetrieveCountryByCityID", IDCity).Tables[0].Rows[0];
            return GetCountryFromDataRow(row);
        }



        // City

        internal static City RetrieveCityByID(int IDCity)
        {
            DataRow row = SqlHelper.ExecuteDataset(cs, "RetrieveCityByID", IDCity).Tables[0].Rows[0];
            return GetCityFromDataRow(row);
        }

        internal static IEnumerable<City> RetrieveCitiesByCountryID(int IDCountry)
        {
            foreach (DataRow row in SqlHelper.ExecuteDataset(cs, "RetrieveCitiesByCountryID", IDCountry).Tables[0].Rows)
            {
                yield return GetCityFromDataRow(row);
            }
        }



        // Customer

        internal static int CreateCustomer(Customer customer)
        {
            return SqlHelper.ExecuteNonQuery(cs, "CreateCustomer", customer.FirstName, customer.LastName, customer.Email, customer.Phone, customer.City.ID);
        }

        internal static Customer RetrieveCustomerByID(int IDCustomer)
        {
            DataRow row = SqlHelper.ExecuteDataset(cs, "RetrieveCustomerByID", IDCustomer).Tables[0].Rows[0];
            return GetCustomerFromDataRow(row);
        }

        internal static Customer RetrieveCustomerByReceiptID(int IDReceipt)
        {
            DataRow row = SqlHelper.ExecuteDataset(cs, "RetrieveCustomerByReceiptID", IDReceipt).Tables[0].Rows[0];
            return GetCustomerFromDataRow(row);
        }

        internal static IEnumerable<Customer> RetrieveAllCustomers()
        {
            foreach (DataRow row in SqlHelper.ExecuteDataset(cs, "RetrieveAllCustomers").Tables[0].Rows)
            {
                yield return GetCustomerFromDataRow(row);
            }
        }

        internal static IEnumerable<Customer> RetrieveCustomersByCityID(int IDCity)
        {
            foreach (DataRow row in SqlHelper.ExecuteDataset(cs, "RetrieveCustomersByCityID", IDCity).Tables[0].Rows)
            {
                yield return GetCustomerFromDataRow(row);
            }
        }

        internal static int UpdateCustomerByID(Customer customer)
        {
            return SqlHelper.ExecuteNonQuery(cs, "UpdateCustomerByID",
                customer.ID,
                customer.FirstName,
                customer.LastName,
                customer.Email,
                customer.Phone,
                customer.City.ID);
        }

        internal static int DeleteCustomerByID(int IDCustomer)
        {
            return SqlHelper.ExecuteNonQuery(cs, "DeleteCustomerByID", IDCustomer);
        }



        // Receipts

        internal static Receipt RetrieveReceiptByID(int IDReceipt)
        {
            DataRow row = SqlHelper.ExecuteDataset(cs, "RetrieveReceiptByID", IDReceipt).Tables[0].Rows[0];
            return GetReceiptFromDataRow(row);
        }

        internal static IEnumerable<Receipt> RetrieveReceiptsByCustomerID(int IDCustomer)
        {
            foreach (DataRow row in SqlHelper.ExecuteDataset(cs, "RetrieveReceiptsByCustomerID", IDCustomer).Tables[0].Rows)
            {
                yield return GetReceiptFromDataRow(row);
            }
        }

        internal static int DeleteReceiptByID(int IDReceipt)
        {
            return SqlHelper.ExecuteNonQuery(cs, "DeleteReceiptByID", IDReceipt);
        }



        // Commercialist

        internal static Commercialist RetrieveCommercialistByID(int IDCommercialist)
        {
            DataRow row = SqlHelper.ExecuteDataset(cs, "RetrieveCommercialistByID", IDCommercialist).Tables[0].Rows[0];
            return GetCommercialistFromDataRow(row);
        }



        // Credit card

        internal static CreditCard RetrieveCreditCardByID(int IDCreditCard)
        {
            DataRow row = SqlHelper.ExecuteDataset(cs, "RetrieveCreditCardByID", IDCreditCard).Tables[0].Rows[0];
            return GetCreditCardFromDataRow(row);
        }



        // Item

        internal static Item RetrieveItemByID(int IDItem)
        {
            DataRow row = SqlHelper.ExecuteDataset(cs, "RetrieveItemByID", IDItem).Tables[0].Rows[0];
            return GetItemFromDataRow(row);
        }

        internal static IEnumerable<Item> RetrieveItemsByReceiptID(int IDReceipt)
        {
            foreach (DataRow row in SqlHelper.ExecuteDataset(cs, "RetrieveItemsByReceiptID", IDReceipt).Tables[0].Rows)
            {
                yield return GetItemFromDataRow(row);
            }
        }

        internal static int DeleteItemByID(int IDItem)
        {
            return SqlHelper.ExecuteNonQuery(cs, "DeleteItemByID", IDItem);
        }




        // Product

        internal static int CreateProduct(Product product)
        {
            if (product.Subcategory != null)
            {
                return SqlHelper.ExecuteNonQuery(cs, "CreateProductWithSubcategory",
                    product.Name,
                    product.Number,
                    product.Color,
                    product.MinimalQuantityInStock,
                    product.PriceWithoutTax,
                    product.Subcategory.ID);
            }
            else
            {
                return SqlHelper.ExecuteNonQuery(cs, "CreateProductWithoutSubcategory",
                    product.Name,
                    product.Number,
                    product.Color,
                    product.MinimalQuantityInStock,
                    product.PriceWithoutTax);
            }
        }

        internal static int CreateProduct(ProductDbm productDbm)
        {
            if (productDbm.SubcategoryID != default)
            {
                return SqlHelper.ExecuteNonQuery(cs, "CreateProductWithSubcategoryID",
                    productDbm.Name,
                    productDbm.Number,
                    productDbm.Color,
                    productDbm.MinimalQuantityInStock,
                    productDbm.PriceWithoutTax,
                    productDbm.SubcategoryID);
            }
            else
            {
                return SqlHelper.ExecuteNonQuery(cs, "CreateProductWithoutSubcategoryID",
                    productDbm.Name,
                    productDbm.Number,
                    productDbm.Color,
                    productDbm.MinimalQuantityInStock,
                    productDbm.PriceWithoutTax);
            }
        }

        internal static Product RetrieveProductByID(int IDProduct)
        {
            DataRow row = SqlHelper.ExecuteDataset(cs, "RetrieveProductByID", IDProduct).Tables[0].Rows[0];
            return GetProductFromDataRow(row);
        }

        internal static IEnumerable<Product> RetrieveAllProducts()
        {
            foreach (DataRow row in SqlHelper.ExecuteDataset(cs, "RetrieveAllProducts").Tables[0].Rows)
            {
                yield return GetProductFromDataRow(row);
            }
        }

        internal static int UpdateProductByID(Product product)
        {
            if (product.Subcategory.ID != default)
            {
                return SqlHelper.ExecuteNonQuery(cs, "UpdateProductByID",
                    product.ID,
                    product.Name,
                    product.Number,
                    product.Color,
                    product.MinimalQuantityInStock,
                    product.PriceWithoutTax,
                    product.Subcategory.ID);
            }
            else
            {
                return SqlHelper.ExecuteNonQuery(cs, "UpdateProductByID",
                    product.ID,
                    product.Name,
                    product.Number,
                    product.Color,
                    product.MinimalQuantityInStock,
                    product.PriceWithoutTax,
                    null);
            }
        }

        internal static int UpdateProductByID(ProductDbm productDbm)
        {
            if (productDbm.SubcategoryID != default)
            {
                return SqlHelper.ExecuteNonQuery(cs, "UpdateProductByID",
                    productDbm.ID,
                    productDbm.Name,
                    productDbm.Number,
                    productDbm.Color,
                    productDbm.MinimalQuantityInStock,
                    productDbm.PriceWithoutTax,
                    productDbm.SubcategoryID);
            }
            else
            {
                return SqlHelper.ExecuteNonQuery(cs, "UpdateProductByID",
                    productDbm.ID,
                    productDbm.Name,
                    productDbm.Number,
                    productDbm.Color,
                    productDbm.MinimalQuantityInStock,
                    productDbm.PriceWithoutTax,
                    null);
            }
        }

        internal static int DeleteProductByID(int IDProduct)
        {
            return SqlHelper.ExecuteNonQuery(cs, "DeleteProductByID", IDProduct);
        }



        // Subcategory

        internal static int CreateSubcategory(Subcategory subcategory)
        {
            return SqlHelper.ExecuteNonQuery(cs, "CreateSubcategory", subcategory.Name, subcategory.Category.ID);
        }

        internal static int CreateSubcategory(SubcategoryDbm subcategoryDbm)
        {
            return SqlHelper.ExecuteNonQuery(cs, "CreateSubcategory", subcategoryDbm.Name, subcategoryDbm.CategoryID);
        }

        internal static Subcategory RetrieveSubcategoryByID(int IDSubcategory)
        {
            DataRow row = SqlHelper.ExecuteDataset(cs, "RetrieveSubcategoryByID", IDSubcategory).Tables[0].Rows[0];
            return GetSubcategoryFromDataRow(row);
        }

        internal static IEnumerable<Subcategory> RetrieveAllSubcategories()
        {
            foreach (DataRow row in SqlHelper.ExecuteDataset(cs, "RetrieveAllSubcategories").Tables[0].Rows)
            {
                yield return GetSubcategoryFromDataRow(row);
            }
        }

        internal static IEnumerable<Subcategory> RetrieveSubcategoriesByCategoryID(int IDCategory)
        {
            foreach (DataRow row in SqlHelper.ExecuteDataset(cs, "RetrieveSubcategoriesByCategoryID", IDCategory).Tables[0].Rows)
            {
                yield return GetSubcategoryFromDataRow(row);
            }
        }

        internal static int UpdateSubcategoryByID(Subcategory subcategory)
        {
            return SqlHelper.ExecuteNonQuery(cs, "UpdateSubcategoryByID",
                subcategory.ID,
                subcategory.Name,
                subcategory.Category.ID);
        }

        internal static int UpdateSubcategoryByID(SubcategoryDbm subcategoryDbm)
        {
            return SqlHelper.ExecuteNonQuery(cs, "UpdateSubcategoryByID",
                subcategoryDbm.ID,
                subcategoryDbm.Name,
                subcategoryDbm.CategoryID);
        }

        internal static int DeleteSubcategoryByID(int IDSubcategory)
        {
            return SqlHelper.ExecuteNonQuery(cs, "DeleteSubcategoryByID", IDSubcategory);
        }



        // Category

        internal static int CreateCategory(Category category)
        {
            return SqlHelper.ExecuteNonQuery(cs, "CreateCategory", category.Name);
        }

        internal static Category RetrieveCategoryByID(int IDCategory)
        {
            DataRow row = SqlHelper.ExecuteDataset(cs, "RetrieveCategoryByID", IDCategory).Tables[0].Rows[0];
            return GetCategoryFromDataRow(row);
        }

        internal static Category RetrieveCategoryBySubcategoryID(int IDSubcategory)
        {
            DataRow row = SqlHelper.ExecuteDataset(cs, "RetrieveCategoryBySubcategoryID", IDSubcategory).Tables[0].Rows[0];
            return GetCategoryFromDataRow(row);
        }

        internal static IEnumerable<Category> RetrieveAllCategories()
        {
            foreach (DataRow row in SqlHelper.ExecuteDataset(cs, "RetrieveAllCategories").Tables[0].Rows)
            {
                yield return GetCategoryFromDataRow(row);
            }
        }

        internal static int UpdateCategoryByID(Category category)
        {
            return SqlHelper.ExecuteNonQuery(cs, "UpdateCategoryByID",
                category.ID,
                category.Name);
        }

        internal static int DeleteCategoryByID(int IDCategory)
        {
            return SqlHelper.ExecuteNonQuery(cs, "DeleteCategoryByID", IDCategory);
        }



        // Private methods

        private static Country GetCountryFromDataRow(DataRow row)
        {
            Country country = new Country
            {
                ID = (int)row["IDDrzava"]
            };

            if (!DBNull.Value.Equals(row["Naziv"]))
            {
                country.Name = row["Naziv"].ToString();
            }

            return country;
        }

        private static City GetCityFromDataRow(DataRow row)
        {
            City city = new City
            {
                ID = (int)row["IDGrad"]
            };

            if (!DBNull.Value.Equals(row["Naziv"]))
            {
                city.Name = row["Naziv"].ToString();
            }

            if (!DBNull.Value.Equals(row["DrzavaID"]))
            {
                city.Country = RetrieveCountryByID((int)row["DrzavaID"]);
            }

            return city;
        }

        private static Customer GetCustomerFromDataRow(DataRow row)
        {
            Customer customer = new Customer
            {
                ID = (int)row["IDKupac"],
                FirstName = row["Ime"].ToString(),
                LastName = row["Prezime"].ToString()
            };

            if (!DBNull.Value.Equals(row["Email"]))
            {
                customer.Email = row["Email"].ToString();
            }

            if (!DBNull.Value.Equals(row["Telefon"]))
            {
                customer.Phone = row["Telefon"].ToString();
            }

            if (!DBNull.Value.Equals(row["GradID"]))
            {
                customer.City = RetrieveCityByID((int)row["GradID"]);
            }

            return customer;
        }

        private static Receipt GetReceiptFromDataRow(DataRow row)
        {
            Receipt receipt = new Receipt
            {
                ID = (int)row["IDRacun"],
                DateOfPurchase = (DateTime)row["DatumIzdavanja"],
                ReceiptNumber = row["BrojRacuna"].ToString(),
                Customer = RetrieveCustomerByID((int)row["KupacID"])
            };

            if (!DBNull.Value.Equals(row["KomercijalistID"]))
            {
                receipt.Commercialist = RetrieveCommercialistByID((int)row["KomercijalistID"]);
            }

            if (!DBNull.Value.Equals(row["KreditnaKarticaID"]))
            {
                receipt.CreditCard = RetrieveCreditCardByID((int)row["KreditnaKarticaID"]);
            }

            if (!DBNull.Value.Equals(row["Komentar"]))
            {
                receipt.Comment = row["Komentar"].ToString();
            }

            return receipt;
        }

        private static Commercialist GetCommercialistFromDataRow(DataRow row)
        {
            Commercialist commercialist = new Commercialist
            {
                ID = (int)row["IDKomercijalist"]
            };

            if (!DBNull.Value.Equals(row["Ime"]))
            {
                commercialist.FirstName = row["Ime"].ToString();
            }

            if (!DBNull.Value.Equals(row["Prezime"]))
            {
                commercialist.LastName = row["Prezime"].ToString();
            }

            if (!DBNull.Value.Equals(row["StalniZaposlenik"]))
            {
                commercialist.PermanentEmployee = (bool)row["StalniZaposlenik"];
            }

            return commercialist;
        }

        private static CreditCard GetCreditCardFromDataRow(DataRow row)
        {
            return new CreditCard
            {
                ID = (int)row["IDKreditnaKartica"],
                Type = row["Tip"].ToString(),
                Number = row["Broj"].ToString(),
                ExpirationMonth = (byte)row["IstekMjesec"],
                ExpirationYear = Convert.ToInt16(row["IstekGodina"])
            };
        }

        private static Item GetItemFromDataRow(DataRow row)
        {
            return new Item
            {
                ID = (int)row["IDStavka"],
                Receipt = RetrieveReceiptByID((int)row["RacunID"]),
                Quantity = Convert.ToInt16(row["Kolicina"]),
                Product = RetrieveProductByID((int)row["ProizvodID"]),
                PriceByPiece = double.Parse(row["CijenaPoKomadu"].ToString(), NumberStyles.Currency),
                Discount = double.Parse(row["PopustUPostocima"].ToString(), NumberStyles.Currency),
                TotalPrice = double.Parse(row["UkupnaCijena"].ToString(), NumberStyles.Currency)
            };
        }

        private static Product GetProductFromDataRow(DataRow row)
        {
            Product product = new Product
            {
                ID = (int)row["IDProizvod"],
                Name = row["Naziv"].ToString(),
                Number = row["BrojProizvoda"].ToString(),
                MinimalQuantityInStock = Convert.ToInt16(row["MinimalnaKolicinaNaSkladistu"]),
                PriceWithoutTax = double.Parse(row["CijenaBezPDV"].ToString(), NumberStyles.Currency)
            };

            if (!DBNull.Value.Equals(row["Boja"]))
            {
                product.Color = row["Boja"].ToString();
            }

            if (!DBNull.Value.Equals(row["PotkategorijaID"]))
            {
                product.Subcategory = RetrieveSubcategoryByID((int)row["PotkategorijaID"]);
            }

            return product;
        }

        private static Subcategory GetSubcategoryFromDataRow(DataRow row)
        {
            return new Subcategory
            {
                ID = (int)row["IDPotkategorija"],
                Category = RetrieveCategoryByID((int)row["KategorijaID"]),
                Name = row["Naziv"].ToString(),
            };
        }

        private static Category GetCategoryFromDataRow(DataRow row)
        {
            return new Category
            {
                ID = (int)row["IDKategorija"],
                Name = row["Naziv"].ToString(),
            };
        }
    }
}