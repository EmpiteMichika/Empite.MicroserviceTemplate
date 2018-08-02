using System.Collections.Generic;
using System.Linq;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Empite.MicroserviceTemplate.Infrastructure.Filter
{
	public class LowercaseDocumentFilter : IDocumentFilter
	{
		public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
		{
			var pathItems = swaggerDoc.Paths;
			var items = new Dictionary<string, PathItem>();
			var keys = new List<string>();
			foreach (var path in pathItems)
			{
				var key = LowercaseEverythingButParameters(path.Key);
				if (key == path.Key) continue;
				keys.Add(path.Key);
				items.Add(key, path.Value);
			}

			foreach (var path in items)
				swaggerDoc.Paths.Add(path.Key, path.Value);
			foreach (var key in keys)
				swaggerDoc.Paths.Remove(key);
		}

		private static string LowercaseEverythingButParameters(string key) => string.Join('/', key.Split('/').Select(x => x.Contains("{") ? x : x.ToLower()));
	}
}
