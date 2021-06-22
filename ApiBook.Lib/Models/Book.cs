using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiBook.Lib.Models
{
	[Table("book")]
    public class Book
	{
		public int id { get; set; }
		public string title { get; set; }
		public string description { get; set; }
		public string isbn { get; set; }
		public string editor { get; set; }
		
		public int? author_id { get; set; }
		public decimal? price { get; set; }
		public DateTime? updated_at { get; set; }
		public DateTime? created_at { get; set; }
		public DateTime? date_release { get; set; }

		[NotMapped]
		public string price_txt { get; set; }

		[NotMapped]
		public string date_release_txt { get; set; }

		[NotMapped]
		public string date_release_hour_txt { get; set; }

		/// <summary>
		/// Configura os dados de saída para exibição em tela.
		/// </summary>
		public void configureOut()
		{
			if ( this.date_release != null)
			{
				this.date_release_txt = this.date_release.Value.ToString("dd/MM/yyyy");
				this.date_release_hour_txt = this.date_release.Value.ToString("HH:mm:ss");
			}
			if ( this.price != null)
			{
				this.price_txt = this.price.Value.ToString("N2");
			}
		}

		/// <summary>
		/// Configura os dados de entrada.
		/// </summary>
		public void configureIn()
		{
			if (this.date_release_txt != null && this.date_release_txt != String.Empty)
			{
				if (this.date_release_hour_txt != null && this.date_release_hour_txt != String.Empty)
				{
					this.date_release = Convert.ToDateTime(this.date_release_txt + " " + this.date_release_hour_txt, new System.Globalization.CultureInfo("pt-BR"));
				}
				else
				{
					this.date_release = Convert.ToDateTime(this.date_release_txt, new System.Globalization.CultureInfo("pt-BR"));
				}
			}

			if (this.price_txt != null && this.price_txt != String.Empty)
			{
				this.price = Convert.ToDecimal(this.price_txt);
			}
		}
	}
}
