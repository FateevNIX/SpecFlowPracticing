Feature: SearchForProductsFeature
	After I search for the product
	It shown on the Search results page

@tearDown
Scenario Outline: Search for products (with use of Outline)
	Given I navigate to the Home page
	When I enter the <ProductName> into search input
	And Click on search button
	Then The search result page is shown
	And Results contains <ProductName>
	When I click on More button for first product
    Then Product details page is shown
    And Product has specific <FullName> and <Price>
	Examples: 
	| ProductName |FullName             | Price |
	| Blouse      | Blouse              | 27.00 |
	| Dress       |Printed Summer Dress | 28.98 |




	