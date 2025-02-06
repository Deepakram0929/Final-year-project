using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using cropPrediction.DLTableAdapters;
using System.Data;

namespace cropPrediction
{
    public class BLL
    {
        //class which contains class members and member functions/
        //in this class we invoke the queries from the data layer(DL.xsd file)

        //class memebers
        tblUsersTableAdapter userObj = new tblUsersTableAdapter();
        tblTypesTableAdapter typeObj = new tblTypesTableAdapter();
        tblCropsTableAdapter cropObj = new tblCropsTableAdapter();
        tblFeatureTypesTableAdapter featuretypeObj = new tblFeatureTypesTableAdapter();
        tblFeaturesTableAdapter featureObj = new tblFeaturesTableAdapter();
        tblFarmersTableAdapter farmerObj = new tblFarmersTableAdapter();
        tblSoilFeaturesTableAdapter soilfeaturesObj = new tblSoilFeaturesTableAdapter();
        tblQueriesTableAdapter queryobj = new tblQueriesTableAdapter();
        //Member Functions
        //login module

        //function to check the user login id and password
        public DataTable CheckUserLogin(string userId, string password)
        {
            return userObj.CheckUserLogin(userId, password);
        }

        //User change Password
        public void UpdateUserPassword(string password, string userId)
        {
            userObj.UpdateUserPassword(password, userId);
        }

        //User management

        //function to insert new User
        public void InsertUser(string userId, string password, string userType, string emailId)
        {
            userObj.InsertUser(userId, password, userType, emailId);
        }

        //function to delete the user
        public void DeleteUser(string userId)
        {
            userObj.DeleteUser(userId);
        }

        //function to get other users
        public DataTable GetOtherUsers()
        {
            return userObj.GetOtherUsers();
        }

        //function to retrive all users based on type
        public DataTable GetUsersByType(string userType)
        {
            return userObj.GetUsersByUserType(userType);
        }

        //function to check the userid
        public bool CheckUserId(string userId)
        {
            int cnt = int.Parse(userObj.CheckUserId(userId).ToString());

            if (cnt == 1)

                return false;

            return true;
        }

        //function to get the user by id
        public DataTable GetUserById(string userId)
        {
            return userObj.GetUserById(userId);
        }

        //function to update the user
        public void UpdateUser(string userId, string password, string type, string emailId, string UId)
        {
            userObj.UpdateUser(userId, password, type, emailId, UId);
        }

        //manage crop types

        //function to check the crop type
        public bool CheckType(string type)
        {
            int cnt = int.Parse(typeObj.CheckCropType(type).ToString());

            if (cnt == 1)

                return false;

            return true;
        }

        //function to insert crop type
        public void InsertType(string type)
        {
            typeObj.InsertType(type);
        }

        //function to update the crop type
        public void UpdateType(string type, int typeId)
        {
            typeObj.UpdateType(type, typeId);
        }

        //function to delete the crop type
        public void DeleteType(int typeId)
        {
            typeObj.DeleteType(typeId);
        }

        //function to get the crop type by id
        public DataTable GetTypeById(int typeId)
        {
            return typeObj.GetTypeById(typeId);
        }

        //function to retrive all crop types
        public DataTable GetTypes()
        {
            return typeObj.GetData();
        }

        //manage Diseases

        //function to check the crop
        public bool CheckCrop(int typeId, string crop)
        {
            int cnt = int.Parse(cropObj.CheckCrop(typeId,crop).ToString());

            if (cnt == 1)

                return false;

            return true;
        }

        //function to insert new crop
        public void InsertCrop(int typeId, string crop)
        {
            cropObj.InsertCrop(typeId, crop);
        }

        //function to get the crop Id by crop name
        public DataTable GetCropIdByName(string crop)
        {
            return cropObj.GetCropIdByName(crop);
        }

        //function to update crop
        public void UpdateCrop(int typeId, string crop, int cropId)
        {
            cropObj.UpdateCrop(typeId, crop, cropId);
        }

        //function to delete crop
        public void DeleteCrop(int cropId)
        {
            cropObj.DeleteCrop(cropId);
        }

        //function to get the crop based on id
        public DataTable GetCropById(int cropId)
        {
            return cropObj.GetCropById(cropId);
        }

        //function to get crop based on type
        public DataTable GetCropsByType(int typeId)
        {
            return cropObj.GetCropsByType(typeId);
        }

        //function to retrive all crops
        public DataTable GetAllCrops()
        {
            return cropObj.GetData();
        }

        //manage feature types

        //function to check the featuretype
        public bool CheckFeatureType(string featuretype)
        {
            int cnt = int.Parse(featuretypeObj.CheckFeatureType(featuretype).ToString());

            if (cnt == 1)

                return false;

            return true;
        }

        //function to insert new featuretype
        public void InsertFeatureType(string featuretype)
        {
            featuretypeObj.InsertFeatureType(featuretype);
        }

        //function to update featuretype
        public void UpdateFeatureType(string featuretype, int featuretypeId)
        {
            featuretypeObj.UpdateFeatureType(featuretype, featuretypeId);
        }

        //function to delete featuretype
        public void DeleteFeatureType(int featuretypeId)
        {
            featuretypeObj.DeleteFeatureType(featuretypeId);
        }

        //function to get the featuretype based on id
        public DataTable GetFeatureTypeById(int featuretypeId)
        {
            return featuretypeObj.GetFeatureTypeById(featuretypeId);
        }

        //function to retrive all featuretypes
        public DataTable GetAllFeatureTypes()
        {
            return featuretypeObj.GetData();
        }

        //manage features

        //function to check the feature
        public bool CheckFeature(int featuretypeId, string feature)
        {
            int cnt = int.Parse(featureObj.CheckFeature(featuretypeId, feature).ToString());

            if (cnt == 1)

                return false;

            return true;
        }

        //function to insert feature
        public void InsertFeature(int featuretypeId, string feature)
        {
            featureObj.InsertFeature(featuretypeId, feature);
        }

        //function to update feature
        public void UpdateFeature(int featuretypeId, string feature, int featureId)
        {
            featureObj.UpdateFeature(featuretypeId, feature, featureId);
        }

        //function to delete feature
        public void DeleteFeature(int featureId)
        {
            featureObj.DeleteFeature(featureId);
        }

        //function to get the feature based on id
        public DataTable GetFeatureById(int featureId)
        {
            return featureObj.GetFeatureById(featureId);
        }

        //function to get features on type
        public DataTable GetFeaturesByType(int featuretypeId)
        {
            return featureObj.GetFeaturesByType(featuretypeId);
        }

        //function to retrive all features
        public DataTable GetAllFetures()
        {
            return featureObj.GetData();
        }

        //manage farmers

        //function to register a new farmer
        public void InsertFarmer(string farmerName, string address, string contactNo,
            DateTime date, string userId)
        {
            farmerObj.InsertFarmer(userId, farmerName, address, contactNo, date);
        }

        //function to update the farmer details
        public void UpdateFarmer(string farmerName, string address, string contactNo, DateTime date, string userId,
           int farmerId)
        {
            farmerObj.UpdateFarmer(userId, farmerName, address, contactNo, date, farmerId);
        }

        //function to update the farmer crop
        public void UpdateFarmerCrop(int cropid, int farmerId)
        {
            farmerObj.UpdateFarmerCrop(cropid, farmerId);
        }

        //function to delete the farmer
        public void DeleteFarmer(int farmerId)
        {
            farmerObj.DeleteFarmer(farmerId);
        }

        //function to retrive all farmers
        public DataTable GetFarmers()
        {
            return farmerObj.GetData();
        }

        public DataTable GetFarmersByLoc(string userId)
        {
            return farmerObj.GetFarmersByLoc(userId);
        }

        public DataTable GetFarmersByLocnCrop(string userId, int cropId)
        {
            return farmerObj.GetFarmersByLocnCrop(userId, cropId);
        }

        //function to get the max farmer id
        public int GetMaxFarmerId()
        {
            return (int)farmerObj.GetMaxFarmerId();
        }

        //function to retrive the farmer details based on id
        public DataTable GetFarmerById(int farmerId)
        {
            return farmerObj.GetFarmerById(farmerId);
        }

        //function to retrive farmers by crop
        public DataTable GetFarmersByCrop(int crop)
        {
            return farmerObj.GetFarmersByCrop(crop);
        }

        //function to retrive the farmers based in name
        public DataTable GetFarmersByName(string farmerName)
        {
            return farmerObj.GetFarmersByName(farmerName);
        }

        //manage farmer soil features

        //function to insert the soil features
        public void InsertFarmerFeature(int farmerId, int featureId)
        {
            soilfeaturesObj.InsertFarmerFeature(farmerId, featureId);
        }

        //function to update the soil feature
        public void UpdateFarmerFeature(int farmerId, int featureId, int PFeatureId)
        {
            soilfeaturesObj.UpdateFarmerFeature(farmerId, featureId, PFeatureId);
        }

        //function to delete the soil feature
        public void DeleteFarmerFeature(int PFeatureId)
        {
            soilfeaturesObj.DeleteFarmerFeature(PFeatureId);
        }

        //function to retrive soil features
        public DataTable GetFarmerFeatures(int farmerId)
        {
            return soilfeaturesObj.GetFarmerFeatures(farmerId);
        }

        //function to get soil feature by id
        public DataTable GetFarmerFeatureById(int SoilId)
        {
            return soilfeaturesObj.GetFarmerFeatureById(SoilId);
        }

        //functiont to delete the soil features
        public void DeleteFarmerFeatures(int farmerId)
        {
            soilfeaturesObj.DeleteFarmerFeatures(farmerId);
        }

        
        public DataTable GetDistinctCropIdByLoc(string loc)
        {
            return farmerObj.GetDistinctCropIdByLoc(loc);
        }


        //query module
        public void InsertQuery(string userId, string query, DateTime posteddate, string pic)
        {
            queryobj.InsertQuery(userId, query, posteddate, pic);
        }

        public void UpdateQuery(string reply, DateTime datetime, int queryId)
        {
            queryobj.UpdateQuery(reply, datetime, queryId);
        }


        public void deleteQuery(int Id)
        {
            queryobj.DeleteQuery(Id);
        }

        public DataTable GetQueryById(int Id)
        {
            return queryobj.GetQueryById(Id);
        }

        public DataTable GetQueryiesBYUserId(string userId)
        {
            return queryobj.GetQueriesByUserId(userId);
        }

        public DataTable GetAllQueries()
        {
            return queryobj.GetData();
        }
                                           
        
    }
}