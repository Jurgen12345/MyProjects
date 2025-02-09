package com.example.final_project_gamestart

class User(val id:String, val username:String, val password:String, val imageId:String){
    var libraryGames = ArrayList<Game>()
    var wishlistedGames = ArrayList<Game>()
}