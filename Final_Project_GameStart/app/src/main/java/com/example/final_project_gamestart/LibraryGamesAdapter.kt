package com.example.final_project_gamestart

import android.content.Context
import android.content.Intent
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.BaseAdapter
import android.widget.Button
import android.widget.ImageView
import android.widget.ListView
import android.widget.TextView
import android.widget.Toast
import androidx.recyclerview.widget.RecyclerView
import org.w3c.dom.Text

class LibraryGamesAdapter(private val context:Context,private val games:ArrayList<Game>)
    : RecyclerView.Adapter<RecyclerView.ViewHolder>(){
    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): RecyclerView.ViewHolder {
        val view = LayoutInflater.from(parent.context).inflate(R.layout.library_layout,parent,false)
        return object: RecyclerView.ViewHolder(view){}
    }

    override fun getItemCount(): Int {
        return games.size
    }

    override fun onBindViewHolder(holder: RecyclerView.ViewHolder, position: Int) {
        val game = games[position]
        val image =holder.itemView.findViewById<ImageView>(R.id.LibraryGameImage)
        val imgdrawable =when(game.image){
            "dark_souls.jpg" ->R.drawable.dark_souls
            "dark_souls_3.jpg" -> R.drawable.dark_souls_3
            "elden_ring.jpg" -> R.drawable.elden_ring
            "skyrim.jpg" -> R.drawable.skyrim
            "league_of_legends.jpg" -> R.drawable.league_of_legends
            "world_of_warcraft.jpg" -> R.drawable.world_of_warcraft
            else -> R.drawable.ic_launcher_background
        }

        image.setImageResource(imgdrawable)
        holder.itemView.findViewById<TextView>(R.id.LibraryGameTitle).text = game.title
        holder.itemView.findViewById<TextView>(R.id.LibraryGameGenre).text = game.Genre
        holder.itemView.findViewById<TextView>(R.id.LibraryGameDescription).text = game.description

        holder.itemView.findViewById<Button>(R.id.LibraryButtonForGames).setOnClickListener{
            UserManager.removeFromLibrary(context,UserManager.currentUser.id){
                Toast.makeText(context, game.title + " has been removed from your library",Toast.LENGTH_LONG).show()
            }

        }

    }

}




