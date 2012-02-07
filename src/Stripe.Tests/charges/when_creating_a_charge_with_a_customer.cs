﻿using Machine.Specifications;

namespace Stripe.Tests
{
    public class when_creating_a_charge_with_a_customer
    {
        protected static StripeChargeCreateOptions StripeChargeCreateOptions;
        protected static StripeCharge StripeCharge;
        protected static StripeCard StripeCard;

        private static StripeChargeService _stripeChargeService;
        private static StripeCustomer _stripeCustomer;

        Establish context = () =>
        {
			var stripeCustomerService = new StripeCustomerService(false);
            _stripeCustomer = stripeCustomerService.Create(test_data.stripe_customer_create_options.ValidCard());

			_stripeChargeService = new StripeChargeService(false);
            StripeChargeCreateOptions = test_data.stripe_charge_create_options.ValidCustomer(_stripeCustomer.Id);
        };

        Because of = () =>
        {
            StripeCharge = _stripeChargeService.Create(StripeChargeCreateOptions);
            StripeCard = _stripeCustomer.StripeCard;
        };

        Behaves_like<charge_behaviors> behaviors;
    }
}