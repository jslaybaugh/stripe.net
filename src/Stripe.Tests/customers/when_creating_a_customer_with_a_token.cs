﻿using System;
using Machine.Specifications;

namespace Stripe.Tests
{
	public class when_creating_a_customer_with_a_token
	{
		protected static StripeCustomerCreateOptions StripeCustomerCreateOptions;
		protected static StripeCustomer StripeCustomer;
		protected static StripePlan StripePlan;
		protected static StripeCoupon StripeCoupon;
		protected static StripeCard StripeCard;

		private static StripeToken _stripeToken;
		private static StripeCustomerService _stripeCustomerService;

        Establish context = () =>
        {
            var _stripePlanService = new StripePlanService(false);
            StripePlan = _stripePlanService.Create(test_data.stripe_plan_create_options.Valid());

            var _stripeCouponService = new StripeCouponService(false);
            StripeCoupon = _stripeCouponService.Create(test_data.stripe_coupon_create_options.Valid());

            var stripeTokenService = new StripeTokenService(false);
            _stripeToken = stripeTokenService.Create(test_data.stripe_token_create_options.Valid());
            
            _stripeCustomerService = new StripeCustomerService(false);
            StripeCustomerCreateOptions = test_data.stripe_customer_create_options.ValidToken(_stripeToken.Id, StripePlan.Id, StripeCoupon.Id, DateTime.UtcNow.AddDays(5));
        };

		Because of = () =>
		{
			StripeCustomer = _stripeCustomerService.Create(StripeCustomerCreateOptions);

			StripeCard = _stripeToken.StripeCard;
		};

		Behaves_like<customer_behaviors> behaviors;
	}
}