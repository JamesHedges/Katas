using System;
using System.Text;
using Shouldly;
using OrderService;
using Xunit;
using Shouldly;
using Moq;
using MediatR;
using System.Threading.Tasks;
using OrderService.Core.Messages;
using OrderService.Core;
using DDD.Core.Domain;

namespace BookClubService.Tests
{
    public class BookClubServiceTests
    {
        [Fact]
        public void BookClubServiceActivateMembership()
        {
            AcceptingPurchaseOrderItemLine acceptingPurchaseOrderItemLine = new AcceptingPurchaseOrderItemLine
            {
                CustomerId = 3344656,
                Item = new ItemLineRequest { Description = "Book Club Membership", Type = ItemLineType.Membership, Category = ItemLineCategory.Book }
            };
            ActivatedMembership activatedMembership = new ActivatedMembership
            {
                Activated = true
            };

            var mockMediator = new Mock<IMediator>();
            IBookClubMembershipRepository bookClubMembershipRepository = GetFakeBookClubMembershipRepository();

            var sut = new BookClubService(mockMediator.Object, bookClubMembershipRepository);

            sut.Handle(acceptingPurchaseOrderItemLine);

            bookClubMembershipRepository.Get(acceptingPurchaseOrderItemLine.CustomerId).ShouldNotBeNull();
        }

        private IBookClubMembershipRepository GetFakeBookClubMembershipRepository()
        {
            var repository = new FakeBookClubMembershipRepository();
            var newMembership = BookClubMembership.Create(3344656);
            repository.Save(newMembership);
            return repository;
        }
    }
}
