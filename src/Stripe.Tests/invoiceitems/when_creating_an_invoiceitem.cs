using Machine.Specifications;

namespace Stripe.Tests
{
	public class when_creating_an_invoiceitem
	{
		protected static StripeInvoiceItemCreateOptions StripeInvoiceItemCreateOptions;
		protected static StripeInvoiceItem StripeInvoiceItem;
		protected static string StripeInvoiceItemId;

		private static StripeInvoiceItemService _stripeInvoiceItemService;

		Establish context = () =>
		{
			var stripeCustomerService = new StripeCustomerService(false);
			var stripeCustomer = stripeCustomerService.Create(test_data.stripe_customer_create_options.ValidCard());

<<<<<<< HEAD
			_stripeInvoiceItemService = new StripeInvoiceItemService(false);
            StripeInvoiceItemCreateOptions = test_data.stripe_invoiceitem_create_options.Valid(stripeCustomer.Id);
        };
=======
			_stripeInvoiceItemService = new StripeInvoiceItemService();
			StripeInvoiceItemCreateOptions = test_data.stripe_invoiceitem_create_options.Valid(stripeCustomer.Id);
		};
>>>>>>> master

		Because of = () =>
			StripeInvoiceItem = _stripeInvoiceItemService.Create(StripeInvoiceItemCreateOptions);

		Behaves_like<invoiceitem_behaviors> behaviors;
	}
}