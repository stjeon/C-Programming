/*Name: Stephen Jeon* (055184139) Date: July 27, 2016 Course: OOP244 Instructor: Eden Burton
Milestone 1 Assignment*/
#include <cstring>
#include <iostream>
#include <iomanip>
#include "ScmApp.h"
#include "ICTCourse.h"
#include "GenEdCourse.h"

using namespace std;

namespace sict{
	ScmApp::ScmApp(){
		//sets all courselists to nullptr and noofcourses to 0 
		for (int ii = 0; ii < MAX_NO_RECS; ii++){
			courseList_[ii] = nullptr;
		}
		noOfCourses_ = 0;
	}

	ScmApp::~ScmApp() {
		//destroys all courselist objects when it is out of scope
		for (int ii = 0; ii <  MAX_NO_RECS; ii++) {
			delete courseList_[ii];
		}
	}

	ScmApp::ScmApp(const char* filename){
		strcpy(filename_, filename);
		for (int ii = 0; ii < MAX_NO_RECS; ii++) {
			delete courseList_[ii];
		}
	}

	//Private member functions
	void ScmApp::pause() const {
		//enters messages and clears buffer
		cout << "Press Enter to continue...";
		while (getchar() != '\n');
	}

	void ScmApp::loadRecs(){
		int readIndex = 0;
		char objectType;

		datafile_.open("file.txt", ios::in);

		if (datafile_.is_open()){
			for (int i = 0; !datafile_.eof(); i++){
				delete courseList_[i];
			}
			while (!datafile_.eof()){
			datafile_.get(objectType);
			if (objectType == 'G'){
				Course* G = new GenEdCourse;
				G->load(datafile_);
				readIndex += 1;
			}
			if (objectType == 'I'){
				Course* I = new ICTCourse;
				I->load(datafile_);
				readIndex += 1;
			}
			else {
				datafile_.ignore(',');
			}
			}
		}
	}

	void ScmApp::saveRecs(){
		datafile_.open(filename_, ios::out);

		for (int i = 0; i < noOfCourses_; i++){
			courseList_[i]->store(datafile_);
		}

		datafile_.close();
	}

	int ScmApp::menu(){
		int option;
		//stores user value in variable option and clears buffer
		cout << "Seneca Course Managment Tool" << endl;
		cout << "1  - List courses." << endl;
		cout << "2. - Display the details of a course." << endl;
		cout << "3. - Add a Course." << endl;
		cout << "4. - Change the study load of a course." << endl;
		cout << "0. - Exit program" << endl;
		cout << ">";
		cin >> option;
		while (getchar() != '\n');
		//false scenario when user enters a false value
		if (option < 0 || option > 4){
			return -1;
		}
		else return option;
	}

	void ScmApp::listCourses()const{
		//formats rows and columns and calls the pause function
		cout << " Row |  Code   |      Course Title      |  Credits | Study |  System   | Language Requirement" << endl;
		cout << "-----|---------|------------------------|----------|-------|-----------|----------------------" << endl;
		for (int ii = 0; ii < noOfCourses_; ii++){
			//loops through the courselist array and displays each element
			cout << right << setw(4) << ii << ' ' << '|' << ' '; cout << *courseList_[ii] << endl;
			//calls the pause function when the loop hits a number of 10.
			if (ii == DISPLAY_LINES){
				pause();
			}
		}
		cout << "---------------------------------------------------------------------------"<<endl;
	}

	int ScmApp::searchForACourse(const char* courseCode)const{
		//searches through the courselist array to find a corresponding coursecode and returns the index
		for (int ii = 0; ii < noOfCourses_; ii++){
			if (*courseList_[ii] == courseCode){
				return ii;
			}
		}
		return -1;
	}

	void ScmApp::changeStudyLoad(const char* courseCode){
		int add;
		//uses the += overload operator to add the user's value to the studyload value of the courselist
		if (searchForACourse(courseCode) != -1){
			cout << "Please enter the amount of the study load:";
			cin >> add;
			*courseList_[searchForACourse(courseCode)] += add;
		}
		else { cout << "Not found!" << endl; }
		while (getchar() != '\n');
		}

	void ScmApp::addACourse(char type){
		char code[MAX_COURSECODE_LEN + 1];//holder variable for the coursecode
		char title[51];//holder variable for the course title
		int credits, study;//holders for the credits and studyload

		if (type==TYPE_ICT){
			char system[7];//holder variable for the computer system
			cout << "Course Code: ";
			cin >> code;
			while (getchar() != '\n');
			cout << "Course Title: ";
			cin.getline(title, 50, '\n');
			cout << "Credits: ";
			cin >> credits;
			cout << "Study Load: ";
			cin >> study;
			cout << "Computer System: ";
			cin >> system;
			while (getchar() != '\n');
			//intakes values from the user and uses the copy constructor to initialize the courselist array
			courseList_[noOfCourses_] = new ICTCourse(code, title, credits, study, system);
			//moves the courselist array by 1
			noOfCourses_ += 1;
		}

		if (type==TYPE_GEN){
			int lang;//holder variable for the language requirement
			cout << "Course Code: ";
			cin >> code;
			while (getchar() != '\n');
			cout << "Course Title: ";
			cin.getline(title, 50, '\n');
			cout << "Credits: ";
			cin >> credits;
			cout << "Study Load: ";
			cin >> study;
			cout << "Language Requirement: ";
			cin >> lang;
			while (getchar() != '\n');
			//intakes values from the user and uses the copy constructor to initialize the courselist array
			courseList_[noOfCourses_] = new GenEdCourse(code, title, credits, study, lang);
			//moves the courselist array by 1
			noOfCourses_ += 1;
		}
	}

	int ScmApp::run(){
		char* code; //users input for the coursecode to use in the search function
		char type;//users input for the course type
		int option; //users menu selection
		code = new char[7];//users code to search is stored here
		do{
			option = menu();
			switch (option){
				//listcourses and pause
			case 1:
				listCourses();
				pause();
				break;
				//Displayfunction. Uses the users code input to search for a course and displays it.
			case 2:
				cout << "Please enter the course code: ";
				cin >> code;
				while (getchar() != '\n');
				if (searchForACourse(code) != -1){
					cout << *courseList_[searchForACourse(code)] << endl;
				}
				else if (searchForACourse(code) == -1){
					cout << "Not found!";
				}
				pause();
				break;
				//Calls the add a course function and pauses.
			case 3:
				cout << "Please enter the course type (I-ICT or G-GenEd): ";
				cin >> type;
				addACourse(type);
				pause();
				break;
				//Searches using the user input and implements the change study load function.
			case 4:
				cout << "Please enter the course code: ";
				cin >> code;
				changeStudyLoad(code);
				pause();
				break;
				//Exit option
			case 0:
				cout << "Goodbye!!";
				break;
				//Invalid selection option
			default:
				cout << "===Invalid Selection, try again.==="<<endl;
			}
			//run loops while the option is not 0.
		} while (option !=0);

		return 0;
	}
	}
