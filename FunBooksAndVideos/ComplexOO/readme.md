Complex Object Oriented FunBooksAndVideo Solution
==================================================

Motivation
----------

When initially solving the FunBooksAndVideo problem, the decision was made to keep it simple and not "over engineer" the solution. This was done with the assumption that all items would be processed based on their ItemLineType. When presented with a business rule that invalidated this assumption, it became painfully obvious that the simple solution was not viable.

You may find the simple solution at [SimpleOOSolution](https://github.com/JamesHedges/Katas/tree/master/FunBooksAndVideos/SimpleOO)

To further generalize the solution, it was decided to take a Domain Driven Design approach. Note that this was the original solution that was deemed "over engineered." With this approach, using domain event will be able to handle the various item processing business rule specifications.

Notes
-----

### Infrastrucure

#### Domain Events

Using the [MediatR](https://github.com/jbogard/MediatR/wiki) Nuget package to facilitate domain events. 

#### Testing

The testing framework is [XUnit](https://xunit.github.io/). Just a matter of preference.

The assertion library [Shouldly](https://github.com/shouldly/shouldly) is used to make the tests a bit easier to reason and the failure message will be generate a friendlier message.

Testing the solution requires a higher level of sophistication. To handle this, the [Moq](https://github.com/moq/moq4) mocking framework has been used instead of fakes and spies.

#### DDD Base

I will be uisng some base DDD objects to handle identity and equality for entities and value objects. Just a few things I have collected along the way.

### Commentary

#### Core

The core will contain objects shared between the modules. This will include all of the messages (commands, responses, and notifications) and the enumerations.

#### Purchase Order

The purchase order has identity and will be an entity that represents the aggregate root. To make this work like a Saga, the purchase order aggregate will be served by a purchase order service. This will rquire the addition of a repository.

An ItemLine is distinguished by its attributes and will be a value object.

#### Purchase Order Processing

The order processing service with handle AcceptPurchaseOrder requests. The handler will iterate through the item lines and publish an AcceptingPurchaseOrderLineItem event. When completed it will return the AcceptedPurchaseOrder response.

#### Business Rule 1

>*If the purchase order contains a membership, it has to be activated in the customer account immediately.*

Adding a membership processing service that handles the AcceptingPurchaseOrderItemLine notification. The handler will check for membership item line type. It if is a membership, it will send the activate request.

#### Business Rule 2

>*If the purchase order contains a physical product a shipping slip has to be generated.*

When a product item line processor will handles the AcceptingPurchaseOrderItemLine notification. The handler check the item type for product. It the item is a product, a request will be sent for create a shipping label.

#### Business Rule 3

>*If the purchase order contains Comprehensive First Aid Training video then Basic First Aid training video is added to the purchase order.*

#### Business Rule 4

>*If the purchase order contains books, and the customer has book membership or bought one then 5 points are added to the customer account for each book.*

#### Business Rule 5

>*If the purchase order contains videos, and the customer has video club membership or bought one then 5 points are added to the customer account for each video.*

