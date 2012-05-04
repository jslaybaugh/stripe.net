using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using System;

namespace Stripe.Tests
{
	public class when_listing_invoices
	{
		private static List<StripeInvoice> _stripeInvoiceList;
		private static StripeCustomer _stripeCustomer;
		private static StripeInvoiceService _stripeInvoiceService;

		Establish context = () =>
		{
			var stripePlanService = new StripePlanService(false);
			var stripePlan = stripePlanService.Create(test_data.stripe_plan_create_options.Valid());

			var stripeCouponService = new StripeCouponService(false);
			var stripeCoupon = stripeCouponService.Create(test_data.stripe_coupon_create_options.Valid());

			var stripeCustomerService = new StripeCustomerService(false);
			var stripeCustomerCreateOptions = test_data.stripe_customer_create_options.ValidCard(stripePlan.Id, stripeCoupon.Id);
			_stripeCustomer = stripeCustomerService.Create(stripeCustomerCreateOptions);

			_stripeInvoiceService = new StripeInvoiceService(false);
		};

		Because of = () =>
			_stripeInvoiceList = _stripeInvoiceService.List(10, 0, _stripeCustomer.Id).ToList();

		It should_have_atleast_1_entry = () =>
			_stripeInvoiceList.Count.ShouldBeGreaterThanOrEqualTo(1);
	}
}