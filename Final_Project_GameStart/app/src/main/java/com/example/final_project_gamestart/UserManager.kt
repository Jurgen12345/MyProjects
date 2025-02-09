package com.example.final_project_gamestart

import android.content.Context
import android.net.Uri
import android.util.Log
import com.android.volley.Request
import com.android.volley.Response
import com.android.volley.toolbox.JsonArrayRequest
import com.android.volley.toolbox.JsonObjectRequest
import com.android.volley.toolbox.Volley
import org.json.JSONArray
import org.json.JSONObject
import kotlin.properties.Delegates

class UserManager {
    companion object{
        var currentUserCount by Delegates.notNull<Int>()
        lateinit var currentUser:User
        var libraryGamesId = ArrayList<String>()
        var wishlistGamesId = ArrayList<String>()
        var users = ArrayList<User>()
        var selectedImage: Uri? = null
        fun authenticateUser(context:Context, username:String, userpassword:String, imageId:String ,authenticated:(User?)->Unit){
            val url  = "https://cs300finalproject-c76be-default-rtdb.europe-west1.firebasedatabase.app/Users.json"
            val requestQueue = Volley.newRequestQueue(context)
            val jsonObjectRequest = JsonObjectRequest(
                Request.Method.GET,
                url,
                null,
                {response ->
                    users.clear()
                    val keys = response.keys()
                    Log.v("response",response.toString())
                    keys.forEach { key->
                        val userObject  = response.getJSONObject(key)
                        val username = userObject.getString("username")
                        val password = userObject.getString("password")
                        val imageId = userObject.getString("imageId")
                        Log.v("username", username)


                        val user = User(key,username,password,imageId)
                        users.add(user)


                    }

                    val authenticatedUser = users.find {
                        it.username == username && it.password == userpassword
                    }

                        authenticated(authenticatedUser)


                },
                {error->
                    error.printStackTrace()

                }


            )
            requestQueue.add(jsonObjectRequest)
        }

        fun createUser(context: Context, username: String,userpassword:String, imageId: String ,created:(User?)->Unit){
            val url  = "https://cs300finalproject-c76be-default-rtdb.europe-west1.firebasedatabase.app/Users.json"
            Log.v("Username in the create user",username)
            val placeholder = JSONArray().put("placeholder")
            val requestQueue = Volley.newRequestQueue(context)
            val phoneData= JSONObject().apply {
                put("username", username)
                put("password",userpassword)
                put("imageId",  imageId)
                put("library",placeholder)
                put("wishlist",placeholder)

            }
            val jsonObjectRequest= JsonObjectRequest(
                Request.Method.POST,
                url,
                phoneData,
                {response ->
                        users.add(User("userid"+ currentUserCount, username, userpassword,imageId))
                        Log.v("User with user added", users.toString())

                    val authenticatedUser = users.find {
                        it.username == username && it.password == userpassword
                    }
                        created(authenticatedUser)

                },
                {error->
                    error.printStackTrace()

                }
            )
            requestQueue.add(jsonObjectRequest)

        }

        fun changeUsername(context: Context, userid: String, changedUsername:String, usernameChanged:()->Unit){
            //val url = "https://cs300finalproject-c76be-default-rtdb.europe-west1.firebasedatabase.app/Users/" + userid + "/username.json"
            val url = "https://cs300finalproject-c76be-default-rtdb.europe-west1.firebasedatabase.app/Users/" + userid + ".json"
            val requestQueue = Volley.newRequestQueue(context)


            val newusername = JSONObject().apply {
                put("username", changedUsername)
            }

            val jsonObjectRequest = JsonObjectRequest(
                Request.Method.PATCH,
                url,
                newusername,
                {response ->
                    usernameChanged()

                },
                {error->
                    error.printStackTrace()

                }
            )
            requestQueue.add(jsonObjectRequest)
        }

        fun changePassword(context: Context, userid: String, changedPassword:String, passwordChanged:()->Unit){
            //val url = "https://cs300finalproject-c76be-default-rtdb.europe-west1.firebasedatabase.app/Users/" + userid + "/username.json"
            val url = "https://cs300finalproject-c76be-default-rtdb.europe-west1.firebasedatabase.app/Users/" + userid + ".json"
            val requestQueue = Volley.newRequestQueue(context)


            val newusername = JSONObject().apply {
                put("password", changedPassword)
            }

            val jsonObjectRequest = JsonObjectRequest(
                Request.Method.PATCH,
                url,
                newusername,
                {response ->
                    passwordChanged()

                },
                {error->
                    error.printStackTrace()

                }
            )
            requestQueue.add(jsonObjectRequest)
        }





        fun addToLibrary(context: Context, userid:String,game:Game, gameadded:()->Unit){
            val url = "https://cs300finalproject-c76be-default-rtdb.europe-west1.firebasedatabase.app/Users/" + userid + ".json"
            val requestQueue = Volley.newRequestQueue(context)
            currentUser.libraryGames.add(game)
            var libraryGameids = ArrayList<String>()
            currentUser.libraryGames.forEach{
                libraryGameids.add(it.id)
            }
            val librarygamlistdata = JSONObject().put("library", JSONArray(libraryGameids))
            val jsonObjectRequest =JsonObjectRequest(
                Request.Method.PATCH,
                url,
                librarygamlistdata,
                {response ->
                    gameadded()

                },
                {error ->
                    error.printStackTrace()

                }
            )
            requestQueue.add(jsonObjectRequest)

        }

        fun addToWishlist(context: Context, userid:String,game:Game, gameadded:()->Unit){
            val url = "https://cs300finalproject-c76be-default-rtdb.europe-west1.firebasedatabase.app/Users/" + userid + ".json"
            val requestQueue = Volley.newRequestQueue(context)
            currentUser.wishlistedGames.add(game)
            var wishlistGameIds = ArrayList<String>()
            currentUser.wishlistedGames.forEach{
                wishlistGameIds.add(it.id)
            }
            val wishlistgamesdata = JSONObject().put("wishlist", JSONArray(wishlistGameIds))
            val jsonObjectRequest =JsonObjectRequest(
                Request.Method.PATCH,
                url,
                wishlistgamesdata,
                {response ->
                    gameadded()

                },
                {error ->
                    error.printStackTrace()

                }
            )
            requestQueue.add(jsonObjectRequest)

        }





        fun removeFromLibrary(context: Context, userid:String, gameRemovedFromLibrary:()->Unit){
            val url = "https://cs300finalproject-c76be-default-rtdb.europe-west1.firebasedatabase.app/Users/" + userid + ".json"
            val requestQueue = Volley.newRequestQueue(context)
            val libraryGameIds =ArrayList<String>()
            currentUser.libraryGames.forEach{
                libraryGameIds.add(it.id)
            }
            val libraryGamesData = JSONObject().put("library",JSONArray(libraryGameIds))
            val jsonObjectRequest = JsonObjectRequest(
                Request.Method.PATCH,
                url,
                libraryGamesData,
                {response ->
                    gameRemovedFromLibrary()

                },
                {error ->
                    error.printStackTrace()

                }
            )
            requestQueue.add(jsonObjectRequest)
        }


        fun removeFromWishlist(context: Context, userid:String, gameRemovedFromWishlist:()->Unit){
            val url = "https://cs300finalproject-c76be-default-rtdb.europe-west1.firebasedatabase.app/Users/" + userid + ".json"
            val requestQueue = Volley.newRequestQueue(context)
            val wishlistgameIds =ArrayList<String>()
            currentUser.wishlistedGames.forEach{
                wishlistGamesId.add(it.id)
            }
            val wishlistGamesData = JSONObject().put("wishlist",JSONArray(wishlistgameIds))
            val jsonObjectRequest = JsonObjectRequest(
                Request.Method.PATCH,
                url,
                wishlistGamesData,
                {response ->
                    gameRemovedFromWishlist()

                },
                {error ->
                    error.printStackTrace()

                }
            )
            requestQueue.add(jsonObjectRequest)
        }




        fun addLibraryToAllUsers(context: Context,usersUpdated: () -> Unit){
            val url = "https://cs300finalproject-c76be-default-rtdb.europe-west1.firebasedatabase.app/Users.json"
            val requestQueue = Volley.newRequestQueue(context)

        }




        fun getLibraryData(context: Context, userid:String, libraryDataFetched:()->Unit){
            val url = "https://cs300finalproject-c76be-default-rtdb.europe-west1.firebasedatabase.app/Users/" + userid + "/library.json"
            val requestQueue = Volley.newRequestQueue(context)
            val jsonArrayRequest = JsonArrayRequest(
                Request.Method.GET,
                url,
                null,
                {response ->
                    Log.v("reponse_++",response.toString())
                    for(i in 0 .. response.length()-1){
                        libraryGamesId.add(response.getString(i))
                    }
                    libraryDataFetched()

                },
                {error->

                    error.printStackTrace()


                }
            )
            requestQueue.add(jsonArrayRequest)
        }

        fun getWishlistData(context: Context, userid:String, wishlistDataFetched:()->Unit){
            val url = "https://cs300finalproject-c76be-default-rtdb.europe-west1.firebasedatabase.app/Users/" + userid + "/wishlist.json"
            val requestQueue = Volley.newRequestQueue(context)
            val jsonArrayRequest = JsonArrayRequest(
                Request.Method.GET,
                url,
                null,
                {response ->
                    Log.v("reponse_++",response.toString())
                    for(i in 0 .. response.length()-1){
                        wishlistGamesId.add(response.getString(i))
                    }
                    wishlistDataFetched()

                },
                {error->

                    error.printStackTrace()


                }
            )
            requestQueue.add(jsonArrayRequest)
        }






        fun isInLibrary(gameid:String) : Boolean{
            return libraryGamesId.contains(gameid)
        }

        fun isInWishList(gameid:String): Boolean{
            return wishlistGamesId.contains(gameid)
        }






    }
}
