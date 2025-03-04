﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Data.OData.Query.SemanticAst
{
	// Token: 0x0200004A RID: 74
	public class ODataPath : ODataAnnotatable, IEnumerable<ODataPathSegment>, IEnumerable
	{
		// Token: 0x060001EC RID: 492 RVA: 0x00007A54 File Offset: 0x00005C54
		public ODataPath(IEnumerable<ODataPathSegment> segments)
		{
			ExceptionUtils.CheckArgumentNotNull<IEnumerable<ODataPathSegment>>(segments, "segments");
			this.segments = segments.ToList<ODataPathSegment>();
			if (this.segments.Any((ODataPathSegment s) => s == null))
			{
				throw Error.ArgumentNull("segments");
			}
		}

		// Token: 0x060001ED RID: 493 RVA: 0x00007AB3 File Offset: 0x00005CB3
		public ODataPath(params ODataPathSegment[] segments)
			: this((IEnumerable<ODataPathSegment>)segments)
		{
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060001EE RID: 494 RVA: 0x00007AC1 File Offset: 0x00005CC1
		public ODataPathSegment FirstSegment
		{
			get
			{
				if (this.segments.Count != 0)
				{
					return this.segments[0];
				}
				return null;
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060001EF RID: 495 RVA: 0x00007ADE File Offset: 0x00005CDE
		public ODataPathSegment LastSegment
		{
			get
			{
				if (this.segments.Count != 0)
				{
					return this.segments[this.segments.Count - 1];
				}
				return null;
			}
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x060001F0 RID: 496 RVA: 0x00007B07 File Offset: 0x00005D07
		public int Count
		{
			get
			{
				return this.segments.Count;
			}
		}

		// Token: 0x060001F1 RID: 497 RVA: 0x00007B14 File Offset: 0x00005D14
		public IEnumerator<ODataPathSegment> GetEnumerator()
		{
			return this.segments.GetEnumerator();
		}

		// Token: 0x060001F2 RID: 498 RVA: 0x00007B21 File Offset: 0x00005D21
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x060001F3 RID: 499 RVA: 0x00007B40 File Offset: 0x00005D40
		public IEnumerable<T> WalkWith<T>(PathSegmentTranslator<T> translator)
		{
			return this.segments.Select((ODataPathSegment segment) => segment.Translate<T>(translator));
		}

		// Token: 0x060001F4 RID: 500 RVA: 0x00007B74 File Offset: 0x00005D74
		public void WalkWith(PathSegmentHandler handler)
		{
			foreach (ODataPathSegment odataPathSegment in this.segments)
			{
				odataPathSegment.Handle(handler);
			}
		}

		// Token: 0x060001F5 RID: 501 RVA: 0x00007BE8 File Offset: 0x00005DE8
		internal bool Equals(ODataPath other)
		{
			ExceptionUtils.CheckArgumentNotNull<ODataPath>(other, "other");
			return this.segments.Count == other.segments.Count && !this.segments.Where((ODataPathSegment t, int i) => !t.Equals(other.segments[i])).Any<ODataPathSegment>();
		}

		// Token: 0x060001F6 RID: 502 RVA: 0x00007C50 File Offset: 0x00005E50
		internal void Add(ODataPathSegment newSegment)
		{
			ExceptionUtils.CheckArgumentNotNull<ODataPathSegment>(newSegment, "newSegment");
			this.segments.Add(newSegment);
		}

		// Token: 0x04000082 RID: 130
		private readonly IList<ODataPathSegment> segments;
	}
}
