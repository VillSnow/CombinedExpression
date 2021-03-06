﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CombinedExpression
{
	static class Helper
	{
		public static IEnumerable<T> MyDistinct<T>(this IEnumerable<T> src) {
			List<T> list = new List<T>();
			foreach (var item in src) {
				if (list.Contains(item)) { continue; }
				list.Add(item);
				yield return item;
			}
		}

		public static IEnumerable<T> MyDistinct<T, TSelector>(this IEnumerable<T> src, Func<T, TSelector> selector) {
			List<T> list = new List<T>();
			foreach (var item in src) {
				if (list.Select(selector).Contains(selector(item))) { continue; }
				list.Add(item);
				yield return item;
			}
		}

		public static IEnumerable<ParameterExpression> DistinctParameters(this IEnumerable<ParameterExpression> source) {

			var list = new List<ParameterExpression>();
			return inner();

			IEnumerable<ParameterExpression> inner() {
				foreach (var item in source) {
					if(list.Where(p=>p.Name== item.Name).SingleOrDefault() is ParameterExpression dup) {
						if (dup.Type != item.Type) {
							throw new InvalidOperationException($"Some parameters are same name buf differ type: {item.Name}");
						} else {
							continue;
						}
					} else {
						list.Add(item);
						yield return item;
					}
				}
			}
		}


		public static IEnumerable<IReadOnlyList<ParameterExpression>> DuplicatedParameters(IEnumerable<ParameterExpression> parameters) {
			if (parameters is IReadOnlyList<ParameterExpression> list) {
				// do nothing
			} else {
				list = parameters.ToList();
			}

			for (int i = 0; i < list.Count; ++i) {
				var lhs = list[i];
				var dups = list.Skip(i + 1).Where(rhs => lhs.Name == rhs.Name && lhs.Type != rhs.Type).ToList();
				if (dups.Any()) {
					yield return dups;
				}
			}
		}
	}
}
