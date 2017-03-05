using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;

using WebApi.Domain;

namespace WebApi.Tests.Domain
{
	[TestFixture]
	public class AgeGroupTests
	{
		[Test]
		public void RangeInclusionLogicTest()
		{
			var groups = new[]
			{
				new AgeGroup
				{
					MinAge = null,
					MaxAge = 2U,
					Description = "low"
				},
				new AgeGroup
				{
					MinAge = 2U,
					MaxAge = 4U,
					Description = "mid"
				},
				new AgeGroup
				{
					MinAge = 4U,
					MaxAge = null,
					Description = "high"
				}
			};

			var expected = new Dictionary<uint, bool[]>
			{
				{ 0U, new[] { true, false, false } },
				{ 1U, new[] { true, false, false } },
				{ 2U, new[] { false, true, false } },
				{ 3U, new[] { false, true, false } },
				{ 4U, new[] { false, false, true } },
				{ 5U, new[] { false, false, true } }
			};

			foreach (var pair in expected)
			{
				CollectionAssert.AreEqual(
					pair.Value,
					groups.Select(group => group.ContainsAge(pair.Key)),
					$"Age: {pair.Key}"
				);
			}
		}
	}
}
