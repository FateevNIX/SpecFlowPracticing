Feature: AddAllItemsToCart
	This feature tests adding of all available items to product cart

@mytag
Scenario: Add all items on Search Results page to cart
	Given I navigate to the Home page
	When I search for the Dress
	Then The search result page is shown
	When I add all available items to cart
	Then Product cart should have '7' products