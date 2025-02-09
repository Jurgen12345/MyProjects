package com.example.final_project_gamestart

import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ImageView
import android.widget.ListView
import android.widget.TextView
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView


class LibraryFragment : Fragment() {


    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

    }

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {

        return inflater.inflate(R.layout.fragment_library, container, false)
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)
        UserManager.getLibraryData(requireContext(),UserManager.currentUser.id){
            val rv = view.findViewById<RecyclerView>(R.id.LibRV)
            val layoutManager = LinearLayoutManager(requireContext())
            val libadapter = LibraryGamesAdapter(requireContext(),UserManager.currentUser.libraryGames)
            rv.adapter = libadapter
            rv.layoutManager = layoutManager


        }





    }

}