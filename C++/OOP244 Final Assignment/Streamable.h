#include "general.h"
#include <iostream>
#include <fstream>
#ifndef SICT_Streamable_h_
#define SICT_Streamable_h_

using namespace std;
namespace sict{
	class Streamable{
	public:
		virtual fstream& store(fstream& file, bool addNewLine = true) const=0;
		virtual fstream& load(std::fstream& file)=0;
		virtual ostream& display(ostream& os) const=0;
		virtual istream& read(istream& is)=0;
	};

}
#endif