package com.example.final_project_gamestart

import android.content.Intent
import android.os.Bundle
import android.widget.Button
import android.widget.ImageView
import android.widget.TextView
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat

class GameInfoActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContentView(R.layout.activity_game_info)
        val gameInfoImage = findViewById<ImageView>(R.id.GameInfoImageView)
        val gameInfoTitle =  findViewById<TextView>(R.id.GameInfoTitle)
        val gameInfoGenre = findViewById<TextView>(R.id.GameInfoGenre)
        val gameInfoDescription = findViewById<TextView>(R.id.GameInfoDescription)
        val backImageView = findViewById<ImageView>(R.id.BackImageView)

        val title =intent.getStringExtra("title")
        val genre = intent.getStringExtra("genre")
        val description = intent.getStringExtra("description")
        val image = intent.getStringExtra("imageId")

        val intimage = when(image){
            "dark_souls.jpg" ->R.drawable.dark_souls
            "dark_souls_3.jpg" -> R.drawable.dark_souls_3
            "elden_ring.jpg" -> R.drawable.elden_ring
            "skyrim.jpg" -> R.drawable.skyrim
            "league_of_legends.jpg" -> R.drawable.league_of_legends
            "world_of_warcraft.jpg" -> R.drawable.world_of_warcraft
            else -> R.drawable.ic_launcher_background
        }


        gameInfoImage.setImageResource(intimage)
        gameInfoTitle.text = title
        gameInfoGenre.text = genre
        gameInfoDescription.text = description

        backImageView.setOnClickListener{
            val intent = Intent(this,HomeActivity::class.java)
            startActivity(intent)
        }





    }
}