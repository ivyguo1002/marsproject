Feature: SearchSkills
	As a user
	I should be able to search skills by categories and by filters

@auto
Scenario: Search Skills by Categories and by SubCategories
	Given I click search icon on Profile Page
	When I click category and subcategory
	Then The search results should be updated by category and subcategory

@auto
Scenario: Search Skills by filters Online
	Given I click search icon on Profile Page
	And I input search skills
	When I choose Filter by Online
	Then The search results should be filtered by Online

@auto
Scenario: Search Skills by filters Onsite
	Given I click search icon on Profile Page
	And I input search skills
	When I choose Filter by OnSite
	Then The search results should be filtered by OnSite

@auto
Scenario: Search Skills by filters ShowAll
	Given I click search icon on Profile Page
	And I input search skills
	When I choose Filter by ShowAll
	Then The search results should be filtered by ShowAll