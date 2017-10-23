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
            ActivateMembership activateMembership = new ActivateMembership
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

            var response = sut.Handle(activateMembership);

            response.Activated.ShouldBeTrue();
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
