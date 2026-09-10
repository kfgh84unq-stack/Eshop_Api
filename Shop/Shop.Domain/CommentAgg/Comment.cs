using Common.Domain;
using Common.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.CommentAgg
{
    public class Comment:AggregateRoot
    {
        public Comment(long userId, string text, long productId)
        {
            NullOrEmptyDomainDataException.CheckString(text,nameof(text));

            UserId = userId;
            Text = text;
            ProductId = productId;
            Status = CommentStatus.Pennding;
        }

        public long UserId { get; private set; }
        public string Text { get; private set; }
        public long ProductId { get; private set; }
        public CommentStatus Status { get; private set; }
        public DateTime LastUpdat { get; private set; }
        public void Edit(string text)
        {
            NullOrEmptyDomainDataException.CheckString(text, nameof(text));

            Text = text;
            LastUpdat = DateTime.Now;
        }
        public void ChangeStatus(CommentStatus status)
        {
            Status = status;
            LastUpdat = DateTime.Now;
        }
    }

    public enum CommentStatus
    {
        Pennding,
        Accepted,
        Rejected
    }
}
