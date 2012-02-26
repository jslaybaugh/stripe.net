﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Stripe
{
	public class StripeEventService: StripeServiceBase
	{
		public StripeEventService() : base() { }
		public StripeEventService(bool liveMode) : base(liveMode) { }

		public StripeEvent Get(string eventId)
		{
			var url = string.Format("{0}/{1}", Urls.Events, eventId);

			var response = Requestor.GetString(url, LiveMode);

			return Mapper<StripeEvent>.MapFromJson(response);
		}

		public IEnumerable<StripeEvent> List(int count = 10, int offset = 0, StripeEventSearchOptions searchOptions = null)
		{
			var url = Urls.Events;
			url = ParameterBuilder.ApplyParameterToUrl(url, "count", count.ToString());
			url = ParameterBuilder.ApplyParameterToUrl(url, "offset", offset.ToString());
			url = ParameterBuilder.ApplyAllParameters(searchOptions, url);

			var response = Requestor.GetString(url, LiveMode);

			return Mapper<StripeEvent>.MapCollectionFromJson(response);
		}
	}
}
