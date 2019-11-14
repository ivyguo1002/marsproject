Feature: ManageListings
	In order to manage the listings
	As a user
	I should be able to edit and delete the service.

@auto
Scenario: Edit a Service
	Given I click Edit button on the first item in Managelistings Page
	Then I should be navigated to ServiceListing Page
	And The Service details should be populated in the ServiceListing Page
	When I edit and update the service
	Then The service should be updated successfully
