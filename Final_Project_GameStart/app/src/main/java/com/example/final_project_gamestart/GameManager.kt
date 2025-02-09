package com.example.final_project_gamestart

import android.content.Context
import com.android.volley.Request
import com.android.volley.toolbox.JsonObjectRequest
import com.android.volley.toolbox.Volley

class GameManager {
    companion object{
        var gamelist =ArrayList<Game>()


        fun getGames(context:Context, datafetched:()->Unit){
            val url = "https://cs300finalproject-c76be-default-rtdb.europe-west1.firebasedatabase.app/Games.json"
            val requestQueue = Volley.newRequestQueue(context)
            val jsonObjectRequest = JsonObjectRequest(
                Request.Method.GET,
                url,
                null,
                {response ->
                    gamelist.clear()
                    val keys = response.keys()
                    keys.forEach { key ->
                        val gameObject =response.getJSONObject(key)
                        val title = gameObject.getString("title")
                        val genre = gameObject.getString("genre")
                        val company = gameObject.getString("company")
                        val release_year = gameObject.getInt("year")
                        val image = gameObject.getString("imageId")
                        val description = gameObject.getString("description")
                        val game =Game(key, title,genre,company,release_year,image,description)
                        gamelist.add(game)
                    }
                    datafetched()

                },
                {error->
                    error.printStackTrace()

                }
            )
            requestQueue.add(jsonObjectRequest)

        }


    }
}