﻿using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Stripe.Infrastructure;

namespace Stripe
{
    public class StripePlanService : StripeServiceBase
    {
		public StripePlanService() : base() { }
		public StripePlanService(bool liveMode) : base(liveMode) { }

		public StripePlan Create(StripePlanCreateOptions createOptions)
		{
			var url = ParameterBuilder.ApplyAllParameters(createOptions, Urls.Plans);

			var response = Requestor.PostString(url, LiveMode);

			return Mapper<StripePlan>.MapFromJson(response);
		}

        public StripePlan Get(string planId)
		{
			var url = string.Format("{0}/{1}", Urls.Plans, planId);

			var response = Requestor.GetString(url, LiveMode);

			return Mapper<StripePlan>.MapFromJson(response);
		}

        public void Delete(string planId)
		{
			var url = string.Format("{0}/{1}", Urls.Plans, planId);

			Requestor.Delete(url, LiveMode);
		}

        public IEnumerable<StripePlan> List(int count = 10, int offset = 0)
		{
			var url = Urls.Plans;
			url = ParameterBuilder.ApplyParameterToUrl(url, "count", count.ToString());
			url = ParameterBuilder.ApplyParameterToUrl(url, "offset", offset.ToString());

			var response = Requestor.GetString(url, LiveMode);

			return Mapper<StripePlan>.MapCollectionFromJson(response);
		}
    }
}