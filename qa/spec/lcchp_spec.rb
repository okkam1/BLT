require 'rubygems'
require 'watir'
require 'watir-webdriver'
require 'yaml'
require 'rspec'

vars = YAML.load_file('.env')
browser = Watir::Browser.new

RSpec.configure do |config|
  config.before(:each) { 
    @browser = browser 
    @site = vars['site']
    @username = vars['username']
    @password = vars['password']
  }
  config.after(:suite) { 
    browser.link(:id, "LoginStatus1").click
    browser.close unless browser.nil?
  }
end

describe "Testing we can enter data into the 'Onboard Lead Research Study Client' Questionnaire" do
  before(:each) do
    @browser.goto @site
  end

  describe "that we can enter data" do
    it "should allow you to login" do
      @browser.text_field(:id, "ContentPlaceHolder1_Login1_UserName").set("#{@username}")
      @browser.text_field(:id, "ContentPlaceHolder1_Login1_Password").set("#{@password}")
      @browser.button(:value,"Log In").click
      @browser.link(:text, "Onboard Lead Research Study Client").click
      @browser.select_list(:id, "ContentPlaceHolder1_FamilyNameList").select("test4 -- 1234 test 92110")
      @browser.text_field(:id, "ContentPlaceHolder1_tbFirstName").set("Frank")
      @browser.text_field(:id, "ContentPlaceHolder1_tbMiddleName").set("Lewis")
      @browser.text_field(:id, "ContentPlaceHolder1_tbBirthDate").set("3/6/2015")
      @browser.radio(:id, "ContentPlaceHolder1_rblGender_0").set
      @browser.select_list(:id, "ContentPlaceHolder1_ddlLanguage").select("DUTCH")
      @browser.text_field(:id, "ContentPlaceHolder1_tbChildID").set("1")
      @browser.text_field(:id, "ContentPlaceHolder1_tbEthnicity").set("White")
      @browser.radio(:id, "ContentPlaceHolder1_rblMoved_0").set
      @browser.radio(:id, "ContentPlaceHolder1_rblSmoker_0").set
      @browser.radio(:id, "ContentPlaceHolder1_rblTravel_0").set
      @browser.textarea(:id, "ContentPlaceHolder1_tbTravelNotes").set("test")
      @browser.radio(:id, "ContentPlaceHolder1_rblOutOfSite_0").set
      @browser.radio(:id, "ContentPlaceHolder1_rblHobby_0").set
      @browser.textarea(:id, "ContentPlaceHolder1_tbHobbyNotes").set("test1")
      @browser.textarea(:id, "ContentPlaceHolder1_tbChildNotes").set("test2")
      @browser.button(:value,"Save and Continue >>").click
      @browser.button(:value,"Next >>").click
      @browser.text_field(:id, "ContentPlaceHolder1_tbQuestionnaireDate").set("03/19/2015")
      @browser.radio(:id, "ContentPlaceHolder1_rblPaintPeeling_0").set
      @browser.text_field(:id, "ContentPlaceHolder1_tbPaintDate").set("03/10/2015")
      @browser.radio(:id, "ContentPlaceHolder1_rblVisitRemodel_0").set
      @browser.text_field(:id, "ContentPlaceHolder1_tbRemodelDate").set("03/24/2015")
      @browser.radio(:id, "ContentPlaceHolder1_rblVitamins_0").set
      @browser.radio(:id, "ContentPlaceHolder1_rblHandWash_0").set
      @browser.radio(:id, "ContentPlaceHolder1_rblBottle_0").set
      @browser.radio(:id, "ContentPlaceHolder1_rblMiniBlinds_0").set
      @browser.radio(:id, "ContentPlaceHolder1_rblNursing_0").set
      @browser.radio(:id, "ContentPlaceHolder1_rblPacifier_0").set
      @browser.radio(:id, "ContentPlaceHolder1_rblBiteNails_0").set
      @browser.radio(:id, "ContentPlaceHolder1_rblEatOutdoors_0").set
      @browser.radio(:id, "ContentPlaceHolder1_rblNonFoodInMouth_0").set
      @browser.radio(:id, "ContentPlaceHolder1_rblEatsNonFood_0").set
      @browser.radio(:id, "ContentPlaceHolder1_rblSucksThumb_0").set
      @browser.radio(:id, "ContentPlaceHolder1_rblMouthing_0").set
      @browser.radio(:id, "ContentPlaceHolder1_rblReview_0").set
      @browser.radio(:id, "ContentPlaceHolder1_rblDayCare_0").set
      @browser.textarea(:id, "ContentPlaceHolder1_tbDaycareNotes").set("test3")
      @browser.textarea(:id, "ContentPlaceHolder1_tbQuestionnaireNotes").set("test4")
      @browser.radio(:id, "ContentPlaceHolder1_rblSource_0").set
      @browser.button(:value,"Save and Continue >>").click
      expect(@browser.text).to include("Failed to Insert New Questionnaire")
      #@browser.button(:value,"Next >>").click
    end
  end
end
