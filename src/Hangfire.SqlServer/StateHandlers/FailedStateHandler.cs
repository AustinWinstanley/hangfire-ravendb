﻿using Hangfire.Common;
using Hangfire.States;
using Hangfire.Storage;
using System;

namespace Hangfire.Raven.StateHandlers
{
    public class FailedStateHandler : IStateHandler
    {
        public void Apply(ApplyStateContext context, IWriteOnlyTransaction transaction)
        {
            transaction.AddToSet("failed", context.JobId, JobHelper.ToTimestamp(DateTime.UtcNow));
        }

        public void Unapply(ApplyStateContext context, IWriteOnlyTransaction transaction)
        {
            transaction.RemoveFromSet("failed", context.JobId);
        }

        public string StateName
        {
            get { return FailedState.StateName; }
        }
    }
}