package com.example.final_project_gamestart

import android.content.Context
import android.os.Bundle
import android.util.Log
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.SearchView
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView


class HomeFragment : Fragment() {



    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

    }


    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {

        return inflater.inflate(R.layout.fragment_home, container, false)
    }


    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)
        val rv =view.findViewById<RecyclerView>(R.id.StoreRV)

        GameManager.getGames(requireContext()){

            val gameadapter = GameAdapter(requireContext(), GameManager.gamelist)
            rv.adapter = gameadapter
            val layoutManager =LinearLayoutManager(context)
            rv.layoutManager = layoutManager
        }

        val homesv = view.findViewById<SearchView>(R.id.SearchGamesView)
        homesv.setOnQueryTextListener(object : SearchView.OnQueryTextListener{
            override fun onQueryTextSubmit(query: String?): Boolean {
                TODO("Not yet implemented")
            }

            override fun onQueryTextChange(newText: String?): Boolean {
                val filteredList = GameManager.gamelist.filter {it ->
                    it.title.contains(newText.orEmpty(),ignoreCase = true)
                }
                val gameadapter = GameAdapter(requireContext(), filteredList as ArrayList<Game>)
                rv.adapter = gameadapter
                return true
            }

        })



    }


}