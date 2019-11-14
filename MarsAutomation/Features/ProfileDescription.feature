Feature: ProfileDescription
	In order to edit my profile
	As a user
	I should be able to edit my profile description

@auto
Scenario: Edit Profile Description
	Given I edit description on Profile Page and click save
	Then The profile description should update and display correctly
